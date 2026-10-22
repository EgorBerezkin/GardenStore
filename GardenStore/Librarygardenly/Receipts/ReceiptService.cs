using System;
using System.Collections.Generic;
using Npgsql;

namespace Librarygardenly.Receipts
{
    public class ReceiptService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";
        private readonly IReceiptRepository repository_;



        // Для тестов — передаём Mock вместо реальной БД
        public ReceiptService(IReceiptRepository repository)
        {
            repository_ = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Для основной программы
        public ReceiptService()
        {
            repository_ = null;
        }

        // метод GetReceipts
        public List<Receipt> GetReceipts()
        {
            if (repository_ != null)
                return repository_.GetReceipts();

            List<Receipt> receipts = new List<Receipt>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT r.id, r.user_id, r.receipt_date, u.full_name, r.items_count, r.total_amount
                                FROM receipts r
                                INNER JOIN users u ON r.user_id = u.id
                                ORDER BY r.receipt_date DESC, r.id DESC";

                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Receipt receipt = new Receipt
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            UserId = Convert.ToInt32(reader["user_id"]),
                            ReceiptDate = Convert.ToDateTime(reader["receipt_date"]),
                            UserFullName = Convert.ToString(reader["full_name"]),
                            ItemsCount = Convert.ToInt32(reader["items_count"]),
                            TotalAmount = Convert.ToDouble(reader["total_amount"])
                        };
                        receipts.Add(receipt);
                    }
                }
            }
            return receipts;
        }

        // метод AddReceipts(Receipt receipt, List items)
        public void AddReceipt(Receipt receipt, List<ReceiptItem> items)
        {
            ValidateReceipt(receipt, items);

            // В тестах вызываем имитатор
            if (repository_ != null)
            {
                repository_.AddReceipt(receipt, items);
                return;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int receiptId = CreateReceipt(connection, transaction, receipt.UserId);
                        int itemsCount = 0;
                        double totalAmount = 0;

                        foreach (ReceiptItem item in items)
                        {
                            int productId = item.ProductId;
                            if (item.NewProduct != null)
                            {
                                productId = CreateProduct(connection, transaction, item.NewProduct);
                            }
                            UpdateProductQuantity(connection, transaction, productId, item.Quantity);
                            SaveReceiptItem(connection, transaction, receiptId, productId, item);

                            itemsCount += item.Quantity;
                            totalAmount += Convert.ToDouble(item.Price) * item.Quantity;
                        }

                        string sql = @"UPDATE receipts
                                        SET items_count = @count, total_amount = @amount
                                        WHERE id = @id";

                        using (var command = new NpgsqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@count", itemsCount);
                            command.Parameters.AddWithValue("@amount", totalAmount);
                            command.Parameters.AddWithValue("@id", receiptId);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        // Проверка поступления и его товаров
        private void ValidateReceipt(Receipt receipt, List<ReceiptItem> items)
        {
            if (receipt == null)
                throw new ArgumentException("Не указано поступление.");

            if (receipt.UserId <= 0)
                throw new ArgumentException("Не указан пользователь.");

            if (items == null || items.Count == 0)
                throw new ArgumentException("Добавьте хотя бы один товар.");

            foreach (ReceiptItem item in items)
            {
                if (item == null)
                    throw new ArgumentException("Обнаружена пустая позиция.");

                if (item.Quantity <= 0)
                    throw new ArgumentException("Количество должно быть больше нуля.");

                if (double.IsNaN(item.Price) || double.IsInfinity(item.Price) || item.Price < 0)
                    throw new ArgumentException("Укажите корректную цену.");

                if (item.NewProduct == null && item.ProductId <= 0)
                    throw new ArgumentException("Выберите товар.");

                if (item.NewProduct != null)
                {
                    if (string.IsNullOrWhiteSpace(item.NewProduct.Name))
                        throw new ArgumentException("Введите название товара.");

                    if (item.NewProduct.CategoryId <= 0)
                        throw new ArgumentException("Выберите категорию товара.");

                    if (double.IsNaN(item.NewProduct.Price) || double.IsInfinity(item.NewProduct.Price) || item.NewProduct.Price < 0)
                        throw new ArgumentException("Укажите корректную цену товара.");
                }
            }
        }

        // Создание записи поступления
        private int CreateReceipt(NpgsqlConnection connection, NpgsqlTransaction transaction, int userId)
        {
            string sql = @"INSERT INTO receipts (user_id, receipt_date)
                            VALUES (@userId, CURRENT_TIMESTAMP)
                            RETURNING id";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@userId", userId);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Создание нового товара
        private int CreateProduct(NpgsqlConnection connection, NpgsqlTransaction transaction, Products.Product product)
        {
            string sql = @"INSERT INTO products (name, category_id, price, quantity, description)
                            VALUES (@name, @categoryId, @price, 0, @description)
                            RETURNING id";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@name", product.Name);
                command.Parameters.AddWithValue("@categoryId", product.CategoryId);
                command.Parameters.AddWithValue("@price", product.Price);
                command.Parameters.AddWithValue("@description", product.Description ?? "");

                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Увеличение остатка на складе
        private void UpdateProductQuantity(NpgsqlConnection connection, NpgsqlTransaction transaction, int productId, int quantity)
        {
            string sql = @"UPDATE products
                            SET quantity = quantity + @quantity
                            WHERE id = @productId";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@productId", productId);

                if (command.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("Товар не найден.");
            }
        }

        // Сохранение позиции поступления
        private void SaveReceiptItem(NpgsqlConnection connection, NpgsqlTransaction transaction, int receiptId, int productId, ReceiptItem item)
        {
            string sql = @"INSERT INTO receipt_items (receipt_id, product_id, quantity, price)
                            VALUES (@receiptId, @productId, @quantity, @price)";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@receiptId", receiptId);
                command.Parameters.AddWithValue("@productId", productId);
                command.Parameters.AddWithValue("@quantity", item.Quantity);
                command.Parameters.AddWithValue("@price", item.Price);
                command.ExecuteNonQuery();
            }
        }

        // метод GetReceiptItems(int receiptId) - получение списка товаров входящих в выбранное поступление
        public List<ReceiptItem> GetReceiptItems(int receiptId)
        {
            if (repository_ != null)
                return repository_.GetReceiptItems(receiptId);

            List<ReceiptItem> items = new List<ReceiptItem>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT ri.id, ri.receipt_id, ri.product_id, p.name, ri.quantity, ri.price
                                FROM receipt_items ri
                                INNER JOIN products p ON ri.product_id = p.id
                                WHERE ri.receipt_id = @receiptId
                                ORDER BY ri.id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@receiptId", receiptId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReceiptItem item = new ReceiptItem
                            {
                                Id = reader.GetInt32(0),
                                ReceiptId = reader.GetInt32(1),
                                ProductId = reader.GetInt32(2),
                                ProductName = reader.GetString(3),
                                Quantity = reader.GetInt32(4),
                                Price = Convert.ToDouble(reader.GetDecimal(5))
                            };
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
            throw new NotImplementedException();
        }
        // для поиска фильтрации
        public List<Receipt> GetReceiptsByFilters(DateTime? date, int? userId)
        {
            if (repository_ != null)
                return repository_.GetReceiptsByFilters(date, userId);

            List<Receipt> receipts = new List<Receipt>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT r.id, r.user_id, r.receipt_date, u.full_name, r.items_count, r.total_amount
                                FROM receipts r
                                INNER JOIN users u ON r.user_id = u.id
                                WHERE 1 = 1";

                if (date.HasValue)
                {
                    sql += @" AND r.receipt_date >= @date AND r.receipt_date < @nextDate";
                }
                if (userId.HasValue)
                {
                    sql += " AND r.user_id = @userId";
                }

                sql += " ORDER BY r.receipt_date DESC, r.id DESC";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    if (date.HasValue)
                    {
                        command.Parameters.AddWithValue("@date", date.Value.Date);
                        command.Parameters.AddWithValue("@nextDate", date.Value.Date.AddDays(1));
                    }

                    if (userId.HasValue)
                    {
                        command.Parameters.AddWithValue("@userId", userId.Value);
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Receipt receipt = new Receipt
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                ReceiptDate = Convert.ToDateTime(reader["receipt_date"]),
                                UserFullName = Convert.ToString(reader["full_name"]),
                                ItemsCount = Convert.ToInt32(reader["items_count"]),
                                TotalAmount = Convert.ToDouble(reader["total_amount"])
                            };
                            receipts.Add(receipt);
                        }
                    }
                }
            }
            return receipts;
            throw new NotImplementedException();
        }
    }
}

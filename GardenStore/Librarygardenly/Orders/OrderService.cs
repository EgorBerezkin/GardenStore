using System;
using System.Collections.Generic;
using Npgsql;

namespace Librarygardenly.Orders
{
    public class OrderService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";
        private readonly IOrderRepository repository_;

        // Для тестов — передаём Mock вместо реальной БД
        public OrderService(IOrderRepository repository)
        {
            repository_ = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        // Для основной программы
        public OrderService()
        {
            repository_ = null;
        }

        // Метод GetOrders
        public List<Order> GetOrders()
        {
            if (repository_ != null)
                return repository_.GetOrders();

            return LoadOrders(null, null);
        }

        // Получение списка продаж с фильтрацией
        private List<Order> LoadOrders(DateTime? date, int? userId)
        {
            List<Order> orders = new List<Order>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT o.id, o.user_id, o.order_date, u.full_name, o.total_sum
                       FROM orders o
                       INNER JOIN users u ON o.user_id = u.id
                       WHERE 1 = 1";

                if (date.HasValue)
                    sql += " AND o.order_date >= @date AND o.order_date < @nextDate";

                if (userId.HasValue)
                    sql += " AND o.user_id = @userId";

                sql += " ORDER BY o.order_date DESC, o.id DESC";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    if (date.HasValue)
                    {
                        command.Parameters.Add("@date", NpgsqlTypes.NpgsqlDbType.Timestamp)
                            .Value = date.Value.Date;

                        command.Parameters.Add("@nextDate", NpgsqlTypes.NpgsqlDbType.Timestamp)
                            .Value = date.Value.Date.AddDays(1);
                    }

                    if (userId.HasValue)
                    {
                        command.Parameters.Add("@userId", NpgsqlTypes.NpgsqlDbType.Integer)
                            .Value = userId.Value;
                    }

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            orders.Add(new Order
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                OrderDate = Convert.ToDateTime(reader["order_date"]),
                                UserFullName = Convert.ToString(reader["full_name"]),
                                TotalAmount = Convert.ToDouble(reader["total_sum"])
                            });
                        }
                    }
                }
            }
            return orders;
        }

        // Метод AddOrder
        public void AddOrder(Order order, List<OrderItem> items)
        {
            ValidateOrder(order, items);

            // В тестах вызываем имитатор
            if (repository_ != null)
            {
                repository_.AddOrder(order, items);
                return;
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        int orderId = CreateOrder(connection, transaction, order.UserId);
                        double totalAmount = 0;

                        foreach (OrderItem item in items)
                        {
                            double price = GetProductPriceAndCheckQuantity(connection, transaction, item.ProductId, item.Quantity);
                            UpdateProductQuantity(connection, transaction, item.ProductId, item.Quantity);
                            SaveOrderItem(connection, transaction, orderId, item, price);

                            totalAmount += price * item.Quantity;
                        }

                        string sql = @"UPDATE orders SET total_sum = @amount WHERE id = @id";

                        using (var command = new NpgsqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@amount", totalAmount);
                            command.Parameters.AddWithValue("@id", orderId);
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

        // Проверка продажи и её товаров
        private void ValidateOrder(Order order, List<OrderItem> items)
        {
            if (order == null)
                throw new ArgumentException("Не указана продажа.");

            if (order.UserId <= 0)
                throw new ArgumentException("Не указан пользователь.");

            if (items == null || items.Count == 0)
                throw new ArgumentException("Добавьте хотя бы один товар.");

            foreach (OrderItem item in items)
            {
                if (item == null)
                    throw new ArgumentException("Обнаружена пустая позиция.");

                if (item.ProductId <= 0)
                    throw new ArgumentException("Выберите товар.");

                if (item.Quantity <= 0)
                    throw new ArgumentException("Количество должно быть больше нуля.");
            }
        }

        // Создание записи продажи
        private int CreateOrder(NpgsqlConnection connection, NpgsqlTransaction transaction, int userId)
        {
            string sql = @"INSERT INTO orders (user_id, order_date, total_sum)
                           VALUES (@userId, CURRENT_TIMESTAMP, 0)
                           RETURNING id";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@userId", userId);
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }

        // Получение цены товара и проверка остатка
        private double GetProductPriceAndCheckQuantity(NpgsqlConnection connection, NpgsqlTransaction transaction, int productId, int quantity)
        {
            string sql = @"SELECT price, quantity
                           FROM products
                           WHERE id = @productId
                           FOR UPDATE";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@productId", productId);

                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        throw new InvalidOperationException("Товар не найден.");

                    double price = Convert.ToDouble(reader["price"]);
                    int availableQuantity = Convert.ToInt32(reader["quantity"]);

                    if (availableQuantity < quantity)
                        throw new InvalidOperationException("Недостаточно товара на складе.");

                    return price;
                }
            }
        }

        // Уменьшение остатка товара на складе
        private void UpdateProductQuantity(NpgsqlConnection connection, NpgsqlTransaction transaction, int productId, int quantity)
        {
            string sql = @"UPDATE products
                           SET quantity = quantity - @quantity
                           WHERE id = @productId";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@productId", productId);

                if (command.ExecuteNonQuery() != 1)
                    throw new InvalidOperationException("Товар не найден.");
            }
        }

        // Сохранение позиции продажи
        private void SaveOrderItem(NpgsqlConnection connection, NpgsqlTransaction transaction, int orderId, OrderItem item, double price)
        {
            string sql = @"INSERT INTO order_items
                           (order_id, product_id, quantity, price)
                           VALUES (@orderId, @productId, @quantity, @price)";

            using (var command = new NpgsqlCommand(sql, connection, transaction))
            {
                command.Parameters.AddWithValue("@orderId", orderId);
                command.Parameters.AddWithValue("@productId", item.ProductId);
                command.Parameters.AddWithValue("@quantity", item.Quantity);
                command.Parameters.AddWithValue("@price", price);
                command.ExecuteNonQuery();
            }
        }

        // Метод GetOrderItems(int orderId) — получение товаров выбранной продажи
        public List<OrderItem> GetOrderItems(int orderId)
        {
            if (repository_ != null)
                return repository_.GetOrderItems(orderId);

            List<OrderItem> items = new List<OrderItem>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT oi.id, oi.order_id, oi.product_id, p.name, oi.quantity, oi.price
                               FROM order_items oi
                               INNER JOIN products p ON oi.product_id = p.id
                               WHERE oi.order_id = @orderId
                               ORDER BY oi.id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@orderId", orderId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            OrderItem item = new OrderItem
                            {
                                Id = reader.GetInt32(0),
                                OrderId = reader.GetInt32(1),
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
        }

        // Для поиска и фильтрации
        public List<Order> GetOrdersByFilters(DateTime? date, int? userId)
        {
            if (repository_ != null)
                return repository_.GetOrdersByFilters(date, userId);

            return LoadOrders(date, userId);
        }
    }
}

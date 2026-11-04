using System;
using System.Collections.Generic;
using Npgsql;

namespace Librarygardenly.Orders
{
    public class OrderService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";

        public List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                string sql = @"SELECT o.id, o.user_id, o.order_date, u.full_name, o.total_sum
                                    FROM orders o
                                    INNER JOIN users u ON o.user_id = u.id
                                    ORDER BY o.order_date DESC, o.id DESC";

                using (var command = new NpgsqlCommand(sql, connection))
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
            return orders;
        }

        // оформление продажи
        public void AddOrder(Order order, List<OrderItem> items)
        {
            ValidateOrder(order, items);

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // создание продажи
                        string sqlOrder = @"INSERT INTO orders (user_id, order_date, total_sum)
                                                    VALUES (@userId, CURRENT_TIMESTAMP, 0)
                                                    RETURNING id";

                        int orderId;
                        using (var command = new NpgsqlCommand(sqlOrder, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", order.UserId);
                            orderId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        double totalAmount = 0;
                        foreach (OrderItem item in items)
                        {
                            // получение цены и остатка товара
                            string sqlProduct = @"SELECT price, quantity
                                                        FROM products
                                                        WHERE id = @productId
                                                        FOR UPDATE";

                            double price;
                            int quantityInStock;
                            using (var command = new NpgsqlCommand(sqlProduct, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@productId", item.ProductId);
                                using (var reader = command.ExecuteReader())
                                {
                                    if (!reader.Read())
                                        throw new InvalidOperationException("Товар не найден.");

                                    price = reader.GetDouble(0);
                                    quantityInStock = reader.GetInt32(1);
                                }
                            }
                            // проверка наличия товара
                            if (quantityInStock < item.Quantity)
                            {
                                throw new InvalidOperationException("Недостаточно товара на складе. Доступно: " + quantityInStock + ", требуется: " + item.Quantity);
                            }

                            // уменьшение количества товара
                            string sqlUpdate = @"UPDATE products
                                                    SET quantity = quantity - @quantity
                                                    WHERE id = @productId";

                            using (var command = new NpgsqlCommand(sqlUpdate, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@quantity", item.Quantity);
                                command.Parameters.AddWithValue("@productId", item.ProductId);
                                command.ExecuteNonQuery();
                            }

                            // сохранение товара
                            string sqlItem = @"INSERT INTO order_items (order_id, product_id, quantity, price)
                                                    VALUES (@orderId, @productId, @quantity, @price)";

                            using (var command = new NpgsqlCommand(sqlItem, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@orderId", orderId);
                                command.Parameters.AddWithValue("@productId", item.ProductId);
                                command.Parameters.AddWithValue("@quantity", item.Quantity);
                                command.Parameters.AddWithValue("@price", price);
                                command.ExecuteNonQuery();
                            }
                            totalAmount += Convert.ToDouble(price) * item.Quantity;
                        }
                        // запись общей суммы
                        string sqlTotal = @"UPDATE orders SET total_sum = @total WHERE id = @orderId";

                        using (var command = new NpgsqlCommand(sqlTotal, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@total", totalAmount);
                            command.Parameters.AddWithValue("@orderId", orderId);
                            command.ExecuteNonQuery();
                        }
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                    }
                }
            }
        }

        // проверка данных продажи
        private void ValidateOrder(Order order, List<OrderItem> items)
        {
            if (order == null)
                throw new ArgumentException("Не указана продажа.");

            if (order.UserId <= 0)
                throw new ArgumentException("Не указан сотрудник.");

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

        // получение товаров
        public List<OrderItem> GetOrderItems(int orderId)
        {
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
                            items.Add(new OrderItem
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                OrderId = Convert.ToInt32(reader["order_id"]),
                                ProductId = Convert.ToInt32(reader["product_id"]),
                                ProductName = Convert.ToString(reader["name"]),
                                Quantity = Convert.ToInt32(reader["quantity"]),
                                Price = Convert.ToDouble(reader["price"])
                            });
                        }
                    }
                }
            }
            return items;
        }
    }
}

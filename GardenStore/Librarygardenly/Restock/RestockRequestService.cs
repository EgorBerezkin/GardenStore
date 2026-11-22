using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Librarygardenly.Restock
{
    public class RestockRequestService
    {
        private string connectionString = "Host=localhost;Database=GardenlyDB;Username=postgres;Encoding=UTF8";

        // Получение всех заявок
        public List<RestockRequest> GetRequests()
        {
            List<RestockRequest> requests = new List<RestockRequest>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT r.id, r.user_id, r.request_date, u.full_name, r.status, COUNT(ri.id) AS items_count, r.total_amount
                                    FROM restock_requests r
                                    INNER JOIN users u ON r.user_id = u.id
                                    LEFT JOIN restock_request_items ri ON r.id = ri.request_id
                                    GROUP BY r.id, r.user_id, r.request_date, u.full_name, r.status, r.total_amount
                                    ORDER BY r.request_date DESC, r.id DESC";

                using (var command = new NpgsqlCommand(sql, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        requests.Add(new RestockRequest
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            UserId = Convert.ToInt32(reader["user_id"]),
                            RequestDate = Convert.ToDateTime(reader["request_date"]),
                            UserFullName = Convert.ToString(reader["full_name"]),
                            Status = Convert.ToString(reader["status"]),
                            CountItems = Convert.ToInt32(reader["items_count"]),
                            TotalAmount = Convert.ToDouble(reader["total_amount"])
                        });
                    }
                }
            }
            return requests;
        }

        // Получение заявок определённого сотрудника
        public List<RestockRequest> GetRequestsByUser(int userId)
        {
            List<RestockRequest> requests = new List<RestockRequest>();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT r.id, r.user_id, r.request_date, u.full_name, r.status, COUNT(ri.id) AS items_count, r.total_amount
                                    FROM restock_requests r
                                    INNER JOIN users u ON r.user_id = u.id
                                    LEFT JOIN restock_request_items ri ON r.id = ri.request_id
                                    WHERE r.user_id = @userId
                                    GROUP BY r.id, r.user_id, r.request_date, u.full_name, r.status, r.total_amount
                                    ORDER BY r.request_date DESC, r.id DESC";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            requests.Add(new RestockRequest
                            {
                                Id = Convert.ToInt32(reader["id"]),
                                UserId = Convert.ToInt32(reader["user_id"]),
                                RequestDate = Convert.ToDateTime(reader["request_date"]),
                                UserFullName = Convert.ToString(reader["full_name"]),
                                Status = Convert.ToString(reader["status"]),
                                CountItems = Convert.ToInt32(reader["items_count"]),
                                TotalAmount = Convert.ToDouble(reader["total_amount"])
                            });
                        }
                    }
                }
            }
            return requests;
        }

        // Добавление новой заявки
        public void AddRequest(RestockRequest request, List<RestockRequestItem> items)
        {
            if (request == null)
                throw new ArgumentNullException(nameof(request));

            if (items == null || items.Count == 0)
                throw new ArgumentException("Добавьте хотя бы один товар в заявку.");

            foreach (RestockRequestItem item in items)
            {
                if (item == null || item.ProductId <= 0 || item.Quantity <= 0)
                    throw new ArgumentException("Проверьте товары и их количество.");
            }

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        double totalAmount = items.Sum(item => item.Quantity * item.Price);

                        string sql = @"INSERT INTO restock_requests (user_id, request_date, status, total_amount)
                                                VALUES (@userId, @requestDate, @status, @totalAmount)
                                                RETURNING id";

                        int requestId;

                        using (var command = new NpgsqlCommand(sql, connection, transaction))
                        {
                            command.Parameters.AddWithValue("@userId", request.UserId);
                            command.Parameters.AddWithValue("@requestDate", request.RequestDate);
                            command.Parameters.AddWithValue("@status", "Ожидает рассмотрения");
                            command.Parameters.AddWithValue("@totalAmount", totalAmount);

                            requestId = Convert.ToInt32(command.ExecuteScalar());
                        }

                        string itemSql = @"INSERT INTO restock_request_items (request_id, product_id, quantity, unit_price)
                                                    VALUES (@requestId, @productId, @quantity, @price)";

                        foreach (RestockRequestItem item in items)
                        {
                            using (var command = new NpgsqlCommand(itemSql, connection, transaction))
                            {
                                command.Parameters.AddWithValue("@requestId", requestId);
                                command.Parameters.AddWithValue("@productId", item.ProductId);
                                command.Parameters.AddWithValue("@quantity", item.Quantity);
                                command.Parameters.AddWithValue("@price", item.Price);

                                command.ExecuteNonQuery();
                            }
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

        // Получение товаров выбранной заявки
        public List<RestockRequestItem> GetRequestItems(int requestId)
        {
            List<RestockRequestItem> items = new List<RestockRequestItem>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"SELECT ri.id, ri.request_id, ri.product_id, p.name, ri.quantity, ri.unit_price
                                        FROM restock_request_items ri
                                        INNER JOIN products p ON ri.product_id = p.id
                                        WHERE ri.request_id = @requestId
                                        ORDER BY ri.id";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@requestId", requestId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(new RestockRequestItem
                            {
                                Id = reader.GetInt32(0),
                                RequestId = reader.GetInt32(1),
                                ProductId = reader.GetInt32(2),
                                ProductName = reader.GetString(3),
                                Quantity = reader.GetInt32(4),
                                Price = reader.GetDouble(5)
                            });
                        }
                    }
                }
            }
            return items;
        }

        // Изменение статуса заявки
        public void UpdateRequestStatus(int requestId, string status)
        {
            if (requestId <= 0)
                throw new ArgumentException("Некорректный номер заявки.");

            if (status != "Одобрена" && status != "Отклонена")
                throw new ArgumentException("Некорректный статус заявки.");

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                string sql = @"UPDATE restock_requests
                                    SET status = @status
                                    WHERE id = @requestId";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@status", status);
                    command.Parameters.AddWithValue("@requestId", requestId);

                    int result = command.ExecuteNonQuery();

                    if (result == 0)
                        throw new Exception("Заявка не найдена.");
                }
            }
        }
    }
}

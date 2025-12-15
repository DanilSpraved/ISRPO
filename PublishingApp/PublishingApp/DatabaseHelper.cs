using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using PublishingApp.Models;

namespace PublishingApp
{
    public class DatabaseHelper
    {
        private string connectionString = @"Data Source=KILLER\SQLEXPRESS;Initial Catalog=Publishing;Integrated Security=True;Connect Timeout=30";

        // Читаем книги — ТОЛЬКО из Publications, без Authors
        public List<Book> GetBooks()
        {
            var books = new List<Book>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id_Publication, Name, Author, ReleaseYear, VolumeOfSheets, Circulation FROM Publications", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        books.Add(new Book
                        {
                            Id = (int)reader["Id_Publication"],
                            Title = reader["Name"].ToString(),
                            AuthorName = reader["Author"].ToString(), // ← Просто текст
                            ReleaseYear = (int)reader["ReleaseYear"],
                            Pages = (int)reader["VolumeOfSheets"],
                            Circulation = (int)reader["Circulation"]
                        });
                    }
                }
            }
            return books;
        }

        // Читаем офисы — как есть
        public List<Office> GetOffices()
        {
            var offices = new List<Office>();
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT Id_Office, Office, Address, Phone FROM Offices", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        offices.Add(new Office
                        {
                            Id = (int)reader["Id_Office"],
                            Name = reader["Office"].ToString(),
                            Address = reader["Address"].ToString(),
                            Phone = reader["Phone"].ToString()
                        });
                    }
                }
            }
            return offices;
        }

        // Создаём клиента
        public int CreateCustomer(Customer customer)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Customers (Name, Type, Address, Phone)
                    VALUES (@Name, @Type, @Address, @Phone);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);

                cmd.Parameters.AddWithValue("@Name", customer.Name ?? "");
                cmd.Parameters.AddWithValue("@Type", customer.Type ?? "Частное лицо");
                cmd.Parameters.AddWithValue("@Address", customer.Address ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone ?? (object)DBNull.Value);

                return (int)cmd.ExecuteScalar();
            }
        }

        // Создаём заказ — ВСЁ ТЕКСТОМ
        public int CreateOrder(Order order)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Orders (Name, Type, Publication, Office, Customer, DateOfAdmission, DateOfCompletion, Price)
                    VALUES (@Name, @Type, @Publication, @Office, @Customer, @DateOfAdmission, @DateOfCompletion, @Price);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);

                cmd.Parameters.AddWithValue("@Name", order.OrderName ?? "");
                cmd.Parameters.AddWithValue("@Type", order.Type ?? "Книга");
                cmd.Parameters.AddWithValue("@Publication", order.BookTitle ?? "");
                cmd.Parameters.AddWithValue("@Office", order.OfficeName ?? "");
                cmd.Parameters.AddWithValue("@Customer", order.CustomerName ?? "");
                cmd.Parameters.AddWithValue("@DateOfAdmission", order.OrderDate);
                cmd.Parameters.AddWithValue("@DateOfCompletion", order.CompletionDate ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Price", order.Price);

                return (int)cmd.ExecuteScalar();
            }
        }

        // Читаем заказ для чека — ТОЛЬКО из Orders
        public Order GetOrderDetails(int orderId)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT Id_Order, Publication, Customer, Office, DateOfAdmission, Price
                    FROM Orders
                    WHERE Id_Order = @Id", conn);
                cmd.Parameters.AddWithValue("@Id", orderId);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Order
                        {
                            Id = (int)reader["Id_Order"],
                            BookTitle = reader["Publication"].ToString(),
                            CustomerName = reader["Customer"].ToString(),
                            OfficeName = reader["Office"].ToString(),
                            OrderDate = (DateTime)reader["DateOfAdmission"],
                            Price = (decimal)reader["Price"]
                        };
                    }
                }
            }
            return null;
        }

        public bool TestConnection()
        {
            try
            {
                using (var conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
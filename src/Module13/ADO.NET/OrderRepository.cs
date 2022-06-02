using ADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET
{
    public class OrderRepository : IRepository<Order>
    {
        private readonly string _connStr;

        public OrderRepository(string connStr)
        {
            _connStr = connStr;
        }

        public async Task AddAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_OrderCreate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", order.Id);
            cmd.Parameters.AddWithValue("@Status", order.Status);
            cmd.Parameters.AddWithValue("@ProductId", order.ProductId);
            cmd.Parameters.AddWithValue("@CreatedDate", order.CreatedDate);
            cmd.ExecuteNonQuery();
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            var orders = new List<Order>();
            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_OrderGetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using var reader = await cmd.ExecuteReaderAsync();
            while(await reader.ReadAsync())
            {
                var order = new Order
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    Status = reader["Status"].ToString(),
                    CreatedDate = (DateTime)(reader["CreatedDate"]),
                    UpdatedDate = (DateTime)(reader["UpdatedDate"])
                };
                orders.Add(order);
            }

            return orders;
        }

        public async Task<Order> GetAsync(int id)
        {
            var order = new Order();
            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_OrderGet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                order = new Order
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ProductId = Convert.ToInt32(reader["ProductId"]),
                    Status = reader["Status"].ToString(),
                    CreatedDate = (DateTime)(reader["CreatedDate"]),
                    UpdatedDate = reader["UpdatedDate"] != DBNull.Value ? (DateTime)(reader["UpdatedDate"]) : null
                };
            }
            return order;
        }

        public async Task RemoveAllAsync()
        {
            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_OrderDeleteAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }

        public async Task RemoveAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_OrderDelete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", order.Id);
            cmd.ExecuteNonQuery();
        }

        public async Task UpdateAsync(Order order)
        {
            if (order == null)
                throw new ArgumentNullException();

            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_OrderUpdate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", order.Id);
            cmd.Parameters.AddWithValue("@Status", order.Status);
            cmd.Parameters.AddWithValue("@UpdatedDate", order.UpdatedDate);
            cmd.ExecuteNonQuery();
        }
    }
}

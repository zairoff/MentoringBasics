using ADO.NET.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly string _connStr;

        public ProductRepository(string connStr)
        {
            _connStr = connStr;
        }

        public async Task AddAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_ProductCreate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Weight", product.Weight);
            cmd.Parameters.AddWithValue("@Height", product.Height);
            cmd.Parameters.AddWithValue("@Width", product.Width);
            cmd.Parameters.AddWithValue("@Length", product.Length);
            cmd.ExecuteNonQuery();
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = new List<Product>();
            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_ProductGetAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Weight = Convert.ToInt64(reader["Weight"]),
                    Height = Convert.ToInt64(reader["Height"]),
                    Width = Convert.ToInt64(reader["Width"]),
                    Length = Convert.ToInt64(reader["Length"])
                };
                products.Add(product);
            }

            return products;
        }

        public async Task<Product> GetAsync(int id)
        {
            var product = new Product();
            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_ProductGet", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            using var reader = await cmd.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                product = new Product
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Name = reader["Name"].ToString(),
                    Description = reader["Description"].ToString(),
                    Weight = Convert.ToInt64(reader["Weight"]),
                    Height = Convert.ToInt64(reader["Height"]),
                    Width = Convert.ToInt64(reader["Width"]),
                    Length = Convert.ToInt64(reader["Length"])
                };
            }
            return product;
        }

        public async Task RemoveAllAsync()
        {
            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_ProductDeleteAll", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }

        public async Task RemoveAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_ProductDelete", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.ExecuteNonQuery();
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException();

            using var connection = new SqlConnection(_connStr);
            await connection.OpenAsync();

            using var cmd = new SqlCommand("pc_ProductUpdate", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Description", product.Description);
            cmd.Parameters.AddWithValue("@Weight", product.Weight);
            cmd.Parameters.AddWithValue("@Height", product.Height);
            cmd.Parameters.AddWithValue("@Width", product.Width);
            cmd.Parameters.AddWithValue("@Length", product.Length);
            cmd.ExecuteNonQuery();
        }
    }
}

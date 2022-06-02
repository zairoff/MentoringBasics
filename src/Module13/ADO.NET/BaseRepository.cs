using ADO.NET.Exceptions;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ADO.NET
{
    // THIS IS NOT USING ANYMORE
    public class BaseRepository
    {
        private readonly string _connStr;
        private readonly string _databaseName;

        public BaseRepository(string connStr, string databaseName)
        {
            _connStr = connStr;
            _databaseName = databaseName;
        }

        public async Task CreateDbAsync()
        {
            try
            {
                using var connection = new SqlConnection(_connStr);
                await connection.OpenAsync();

                using var cmd = new SqlCommand(GetDbCreateQuery(_databaseName), connection);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                using var connection = new SqlConnection($"{_connStr}; Database={_databaseName}");
                await connection.OpenAsync();

                using var cmd = new SqlCommand(GetDbQuery(), connection);
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                throw new DataBaseException(ex.Message);
            }
        }

        private static string GetDbCreateQuery(string databaseName)
        {
            return $@"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{databaseName}')
                        BEGIN
                            CREATE DATABASE {databaseName};
                        END;";
        }

        private static string GetDbQuery()
        {
            var query = $@"
                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Products' and xtype='U')
                        BEGIN
                            CREATE TABLE Products (
                                Id INT PRIMARY KEY IDENTITY (1, 1),
                                Name NVARCHAR(100),
                                Description NVARCHAR(100),
                                Weight Decimal(5,3),
                                Height Decimal(5,3),
                                Width Decimal(5,3),
                                Length Decimal(5,3)
                            )
                        END;

                        IF NOT EXISTS (SELECT * FROM sysobjects WHERE name='Orders' and xtype='U')
                        BEGIN
                            CREATE TABLE Orders (
                                Id INT PRIMARY KEY IDENTITY (1, 1),
                                Status NVARCHAR(50),
                                ProductId int,
                                CreatedDate Date,
                                UpdatedDate Date,
                                Foreign key (ProductId) references Products(Id)
                            )
                        END;

                        IF EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_ProductCreate'
                                AND type = 'P')
                        BEGIN
                            DROP PROCEDURE dbo.pc_ProductCreate
                        END;
                          
                        CREATE PROCEDURE pc_ProductCreate
                                                        @Name NVARCHAR(100),
                                                        @Description NVARCHAR(100),
                                                        @Weight Decimal(5,3),
                                                        @Height Decimal(5,3),
                                                        @Width Decimal(5,3),
                                                        @Length Decimal(5,3)
                          AS
                            INSERT INTO PRODUCT (NAME, DESCRIPTION, WEIGHT, HEIGHT, WIDTH, LENGTH)
                                    VALUES (@NAME, @DESCRIPTION, @WEIGHT, @HEIGHT, @WIDTH, @LENGTH);
                        
                          

                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_ProductUpdate'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_ProductUpdate
                                                        @Id int,
                                                        @Name NVARCHAR(100),
                                                        @Description NVARCHAR(100),
                                                        @Weight Decimal(5,3),
                                                        @Height Decimal(5,3),
                                                        @Width Decimal(5,3),
                                                        @Length Decimal(5,3)
                          AS
                            UPDATE PRODUCTS SET NAME = @NAME, Description = @Description, Weight = @Weight,
                                    Height = @Height, Width = @Width, Length = @Length
                                    WHERE ID = @ID;
                        
                          END;


                        IF EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_ProductDelete'
                                AND type = 'P')
                            BEGIN
		                        DROP PROCEDURE dbo.pc_ProductDelete
	                        END
                                CREATE PROCEDURE pc_ProductDelete
                                                        @Id int                                                       
                          AS
                            DELETE FROM PRODUCTS WHERE ID = @Id;                        
                          END;

                         IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_ProductDeleteAll'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_ProductDeleteAll
                          AS
                            DELETE FROM PRODUCTS;                       
                          END;

                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_ProductGetAll'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_ProductGetAll
                          AS
                            SELECT *FROM PRODUCTS;                      
                          END;

                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_OrdersGet'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_OrdersGet @Id int
                          AS
                            SELECT *FROM ORDERS WHERE ID=@ID;                       
                          END;


                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_OrdersGetAll'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_OrdersGetAll
                          AS
                            SELECT *FROM ORDERS;                      
                          END;

                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_OrdersDeleteAll'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_OrdersDeleteAll
                          AS
                            DELETE FROM ORDERS;                      
                          END;


                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_OrdersDelete'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_OrdersDelete @Id int
                          AS
                            DELETE FROM ORDERS WHERE ID = @Id;                      
                          END;


                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_OrdersCreate'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_OrdersCreate
                                                    @Status NVARCHAR(50),
                                                    @ProductId int,
                                                    @CreatedDate Date
                          AS
                            INSERT INTO ORDERS (STATUS, PRODUCTID, CREATEDDATE, UPDATEDDATE) 
                                        VALUES(@STATUS, @PRODUCTID, @CREATEDDATE, @UPDATEDDATE);
                          END;


                        IF NOT EXISTS (SELECT type_desc, type FROM sys.procedures
                                        WITH(NOLOCK) WHERE NAME = 'pc_OrdersUpdate'
                                AND type = 'P')
                          BEGIN
                                CREATE PROCEDURE pc_OrdersUpdate
                                                    @Id INT
                                                    @Status NVARCHAR(50),
                                                    @UpdatedDate Date
                          AS
                            UPDATE ORDERS SET STATUS = @STATUS, UPDATEDDATE = @UPDATEDDATE WHERE ID = @ID;
                          END;
                         ";

            return query;
        }
    }
}

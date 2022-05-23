using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperCRUDAPI.Model
{
    public class ProductRepository
    {
        private string connectionString;
        public ProductRepository()
        {
            connectionString = @"Persist Security Info=False;User ID=sa;password=123;Initial Catalog=DAPPERDB; Data Source=DESKTOP-9J6501O\SQLEXPRESS;Connection Timeout=100000;";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void CreateProduct(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Products (Name,Quantity,Price) VALUES(@Name,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetAllProducts()
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }

        public Product GetProductById(int id)
        {
            using(IDbConnection dbConnection = Connection)
            {
                string sQuery = @"Select * FROM Products Where ProductId=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void DeleteProject(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Products Where ProductId=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void UpdateProject(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Products SET Name=@Name,Quantity=@Quantity,Price=@Price Where ProductId=@ProductId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }


    }
}

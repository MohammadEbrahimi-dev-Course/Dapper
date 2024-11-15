using Dapper;
using DapperExam.Models;
using System.Data.SqlClient;

namespace DapperExam.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetAllProduct();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(int id);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly ICommandText _commandText;
        private readonly string _connectionString;
        public ProductRepository(ICommandText commandText, IConfiguration configuration)
        {
            _commandText = commandText;
            _connectionString = configuration.GetConnectionString("Dapper");
        }

        public List<Product> GetAllProduct()
        {
            var query = ExecuteCommand(_connectionString, conn => conn.Query<Product>(_commandText.GetProducts))
                 .ToList();

            return query;
        }
        public Product GetProductById(int id)
        {
            var query = ExecuteCommand<Product>(_connectionString, conn => conn.Query<Product>(_commandText.GetProductById, new { @Id = id })
            .SingleOrDefault());

            return query;
        }


        public void AddProduct(Product product)
        {
            ExecuteCommand(_connectionString,
                conn => conn.Query<Product>(_commandText.AddProduct,
                new { Name = product.Name, Cost = product.Cost, CreateDate = product.CreateDate }));
        }

        public void UpdateProduct(Product product)
        {
            ExecuteCommand(_connectionString,
                conn => conn.Query<Product>(_commandText.UpdateProduct,
                new { Name = product.Name, Cost = product.Cost, CreateDate = product.CreateDate, Id = product.Id }));
        }

        public void RemoveProduct(int id)
        {
            ExecuteCommand(_connectionString,
                conn => conn.Query<Product>(_commandText.RemoveProduct,
                    new { Id = id }));
        }

        #region Helpers
        // به متد های پرایورت یک کلاس میگن utilities ابزار های اون کلاس

        private void ExecuteCommand(string connection, Action<SqlConnection> task)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                task(conn);
            }
        }

        private T ExecuteCommand<T>(string connection, Func<SqlConnection, T> task)
        {
            using (var conn = new SqlConnection(connection))
            {
                conn.Open();
                return task(conn);
            }
        }
        #endregion
    }
}

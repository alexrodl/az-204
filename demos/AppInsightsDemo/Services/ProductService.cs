using AppInsightsDemo.Models;
using Microsoft.Data.SqlClient;

namespace AppInsightsDemo.Services
{
    public class ProductService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<ProductService> _logger;

        public ProductService(IConfiguration configuration, ILogger<ProductService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            _logger.LogInformation("Loading products from Azure SQL");

            var products = new List<Product>();

            await using var connection = new SqlConnection(_configuration.GetConnectionString("AzureSqlDatabase"));

            await connection.OpenAsync();

            const string sql = """
            SELECT TOP (10)
                [ProductID],
                [Name],
                [ProductNumber]
            FROM [SalesLT].[Product]
            """;

            await using var command = new SqlCommand(sql, connection);

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                products.Add(
                    new Product
                    {
                        ProductID =
                            reader.GetInt32(0),

                        Name =
                            reader.GetString(1),

                        ProductNumber =
                            reader.GetString(2)
                    });
            }

            return products;
        }
    }
}

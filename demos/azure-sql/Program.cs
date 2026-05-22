using Microsoft.Data.SqlClient;

string serverName = "az-204-sqlserver.database.windows.net";
string connectionString = $"Server=tcp:{serverName},1433;Initial Catalog=az-204-database;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Authentication=Active Directory Default;";

using (SqlConnection connection = new SqlConnection(connectionString))
{
    try
    {
        connection.Open();
        Console.WriteLine("Connection successful!");

        SqlCommand qry = new SqlCommand("SELECT * FROM SalesLT.Product", connection);
        SqlDataReader reader = qry.ExecuteReader();
        while (reader.Read())
        {
            Console.WriteLine($"{reader["ProductID"]}, {reader["Name"]}, {reader["ProductNumber"]}, {reader["Color"]}, {reader["StandardCost"]}, {reader["ListPrice"]}");
        }

    }
    catch (SqlException ex)
    {
        Console.WriteLine($"Connection failed: {ex.Message}");
    }
}
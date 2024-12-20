using Npgsql;

namespace Infrostructure.DataContext;

public class DapperContext: IDapperContext
{
    private readonly string connectionString = "Server=localhost;Port=5432;Database=SimpleShopDb;Username=postgres;Password=12345";
    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(connectionString);
    }
}
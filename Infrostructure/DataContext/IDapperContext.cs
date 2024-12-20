using Npgsql;

namespace Infrostructure.DataContext;

public interface IDapperContext
{
    NpgsqlConnection Connection();
}
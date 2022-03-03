using System.Data;
using Npgsql;
using Sanirasu.Settings;

namespace Sanirasu.Repositories;

public class BaseRepository
{
    private readonly IConfiguration _configuration;
    public BaseRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public NpgsqlConnection NewConnection => new NpgsqlConnection(_configuration.GetSection(nameof(PostgresSettings)).Get<PostgresSettings>().ConnectionString);

}
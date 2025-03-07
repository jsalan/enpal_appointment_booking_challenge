using System.Data.Common;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace AppointmentBooking.Application.FunctionalTests;

public class PostgresqlTestDatabase : ITestDatabase
{
    private readonly NpgsqlConnection _connection;

    public PostgresqlTestDatabase()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();

        _connection = new NpgsqlConnection(configuration.GetConnectionString("CodingChallengeDb"));
    }

    public DbConnection GetConnection()
    {
        return _connection;
    }

    public async Task DisposeAsync()
    {
        await _connection.DisposeAsync();
    }
}
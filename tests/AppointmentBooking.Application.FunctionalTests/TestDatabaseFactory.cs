namespace AppointmentBooking.Application.FunctionalTests;

public static class TestDatabaseFactory
{
    public static ITestDatabase CreateAsync()
    {
        return new PostgresqlTestDatabase();
    }
}

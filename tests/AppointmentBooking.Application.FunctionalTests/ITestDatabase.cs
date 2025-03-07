using System.Data.Common;

namespace AppointmentBooking.Application.FunctionalTests;

public interface ITestDatabase
{
    DbConnection GetConnection();
    Task DisposeAsync();
}
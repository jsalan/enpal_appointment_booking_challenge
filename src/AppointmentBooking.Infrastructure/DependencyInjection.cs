using AppointmentBooking.Application.Common.Interfaces;
using AppointmentBooking.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AppointmentBooking.Infrastructure;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, string? connectionString)
    {
        services.AddDbContext<ApplicationDbContext>((_, options) => { options.UseNpgsql(connectionString); });

        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    }
}
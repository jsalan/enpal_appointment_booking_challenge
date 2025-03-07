using System.Text.Json.Serialization;
using AppointmentBooking.WebApi.Helpers;

namespace AppointmentBooking.WebApi;

public static class DependencyInjection
{
    public static void AddWebApiServices(this IServiceCollection services)
    {
        services.AddControllers().AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            options.JsonSerializerOptions.Converters.Add(new DateTimeOffsetConverter());
        });

        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }
}
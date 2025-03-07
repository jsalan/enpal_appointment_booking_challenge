using AppointmentBooking.Application;
using AppointmentBooking.Infrastructure;
using AppointmentBooking.WebApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration.GetConnectionString("CodingChallengeDb"));
builder.Services.AddWebApiServices();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler(_ => { });

app.MapControllers();

app.Run();

public partial class Program;
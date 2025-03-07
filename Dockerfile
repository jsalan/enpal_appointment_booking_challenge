FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

WORKDIR /app

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

ARG BUILD_CONFIGURATION=Release

WORKDIR /src

COPY ["src/AppointmentBooking.Domain/AppointmentBooking.Domain.csproj", "src/AppointmentBooking.Domain/"]
COPY ["src/AppointmentBooking.Application/AppointmentBooking.Application.csproj", "src/AppointmentBooking.Application/"]
COPY ["src/AppointmentBooking.Infrastructure/AppointmentBooking.Infrastructure.csproj", "src/AppointmentBooking.Infrastructure/"]
COPY ["src/AppointmentBooking.WebApi/AppointmentBooking.WebApi.csproj", "src/AppointmentBooking.WebApi/"]

RUN dotnet restore "src/AppointmentBooking.WebApi/AppointmentBooking.WebApi.csproj"

COPY src .

WORKDIR "/src/AppointmentBooking.WebApi"

RUN dotnet build "AppointmentBooking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish

ARG BUILD_CONFIGURATION=Release

RUN dotnet publish "AppointmentBooking.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final

WORKDIR /app

COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "AppointmentBooking.WebApi.dll"]

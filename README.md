![Enpal Logo](assets/enpal_logo.png)

---

Appointment Booking
===================

The goal of this project is to build an appointment booking system that allows customers to schedule appointments with sales managers to discuss one or more of the products. This is an API that displays available appointment slots that a customer can choose from.

There are a few rules we need to consider when checking for available appointment slots for a customer:

* Each slot corresponds to a one-hour appointment
* Slots can have overlapping time ranges. For example, it is possible to have the following three slots:
    * 10:30 - 11:30
    * 11:00 - 12:00
    * 11:30 - 12:30
* A sales manager CANNOT be booked for two overlapping slots at the same time. For example, if a sales manger has a slot booked at 10:30 - 11:30, then the 11:00 - 12:00 cannot be booked anymore.
* Customers are matched to sales managers based on specific criteria. A slot CANNOT be booked by a customer if the sales
  manager
  does not match any of these three criteria:
    * Language. Currently, we have 2 possible languages: German, English
    * Product(s) to discuss. Currently, we have 2 possible products: SolarPanels, Heatpumps
    * Internal customer rating. Currently, we have 3 possible ratings: Gold, Silver, Bronze.
* Customers can book one appointment to discuss multiple products

## Getting started

This solution uses .NET for running the API and Postgres for storage.

The `Appointment Booking` API will be running at [http://localhost:3000](http://localhost:3000).

### Run in Docker

Run in this directory to build and run the app:

```shell
docker compose up -d
```

or

* For database:
```shell
docker build -t enpal-coding-challenge-db ./database/.
docker run --name enpal-coding-challenge-db -p 5432:5432 -d enpal-coding-challenge-db
```
* For API:
```shell
docker build -t enpal-coding-challenge-api .
docker run --name enpal-coding-challenge-api -p 3000:8080 --add-host=host.docker.internal:host-gateway -d enpal-coding-challenge-api
```

### Run on local machine

To run this on a local machine you need to first run the database in Docker.

And for the API you need to first download and install [.Net 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0). Then run in this directory to build and run the app:

```shell
dotnet run --project ./src/AppointmentBooking.WebApi/AppointmentBooking.WebApi.csproj --environment "Development"
```

You can also use your own favorite IDE.

### Testing

Run in this directory to build and run the tests:

```shell
dotnet test ./tests/AppointmentBooking.Application.UnitTests/AppointmentBooking.Application.UnitTests.csproj
dotnet test ./tests/AppointmentBooking.Application.FunctionalTests/AppointmentBooking.Application.FunctionalTests.csproj
```

---

In the end I want to thank you for taking time and review my code.

If you have any question, please give me an email at [j.s.alan@outlook.com](mailto:j.s.alan@outlook.com).
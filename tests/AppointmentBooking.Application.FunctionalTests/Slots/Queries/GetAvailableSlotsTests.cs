using AppointmentBooking.Application.Slots.Queries.GetAvailableSlots;
using AppointmentBooking.Domain.Enums;
using FluentAssertions;

namespace AppointmentBooking.Application.FunctionalTests.Slots.Queries;

public class GetAvailableSlotsTests
{
    [Test]
    public async Task OnlySeller2IsSelectable()
    {
        var query = new GetAvailableSlotsQuery
        {
            Date = new DateOnly(2024, 5, 3),
            Products = [Product.SolarPanels, Product.Heatpumps],
            Language = Language.German,
            Rating = CustomerRating.Gold
        };

        var result = await Setup.SendAsync(query);

        result.Should().HaveCount(3);

        var expected = new[]
        {
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 10, 30, 00), TimeSpan.Zero)
            },
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 11, 00, 00), TimeSpan.Zero)
            },
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 11, 30, 00), TimeSpan.Zero)
            }
        };

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public async Task BothSeller2AndSeller3AreSelectable()
    {
        var query = new GetAvailableSlotsQuery
        {
            Date = new DateOnly(2024, 5, 3),
            Products = [Product.Heatpumps],
            Language = Language.English,
            Rating = CustomerRating.Silver
        };

        var result = await Setup.SendAsync(query);

        result.Should().HaveCount(3);

        var expected = new[]
        {
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 10, 30, 00), TimeSpan.Zero)
            },
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 11, 00, 00), TimeSpan.Zero)
            },
            new AvailableSlotViewModel
            {
                AvailableCount = 2,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 11, 30, 00), TimeSpan.Zero)
            }
        };

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public async Task AllSeller1And2AreSelectableButSeller1DoesNotHaveAvailableSlots()
    {
        var query = new GetAvailableSlotsQuery
        {
            Date = new DateOnly(2024, 5, 3),
            Products = [Product.SolarPanels],
            Language = Language.German,
            Rating = CustomerRating.Bronze
        };

        var result = await Setup.SendAsync(query);

        result.Should().HaveCount(3);

        var expected = new[]
        {
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 10, 30, 00), TimeSpan.Zero)
            },
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 11, 00, 00), TimeSpan.Zero)
            },
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 03, 11, 30, 00), TimeSpan.Zero)
            }
        };

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public async Task OnlySeller2IsSelectableButItIsFullyBooked()
    {
        var query = new GetAvailableSlotsQuery
        {
            Date = new DateOnly(2024, 5, 4),
            Products = [Product.SolarPanels, Product.Heatpumps],
            Language = Language.German,
            Rating = CustomerRating.Gold
        };

        var result = await Setup.SendAsync(query);

        result.Should().BeEmpty();
    }

    [Test]
    public async Task BothSeller2AndSeller3AreSelectableButSeller2IsFullyBooked()
    {
        var query = new GetAvailableSlotsQuery
        {
            Date = new DateOnly(2024, 5, 4),
            Products = [Product.Heatpumps],
            Language = Language.English,
            Rating = CustomerRating.Silver
        };

        var result = await Setup.SendAsync(query);

        result.Should().HaveCount(1);

        var expected = new[]
        {
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 04, 11, 30, 00), TimeSpan.Zero)
            }
        };

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }

    [Test]
    public async Task Seller1And2AreSelectableButSeller2IsFullyBooked()
    {
        var query = new GetAvailableSlotsQuery
        {
            Date = new DateOnly(2024, 5, 4),
            Products = [Product.SolarPanels],
            Language = Language.German,
            Rating = CustomerRating.Bronze
        };

        var result = await Setup.SendAsync(query);

        result.Should().HaveCount(1);

        var expected = new[]
        {
            new AvailableSlotViewModel
            {
                AvailableCount = 1,
                StartDate = new DateTimeOffset(new DateTime(2024, 05, 04, 10, 30, 00), TimeSpan.Zero)
            }
        };

        result.Should().BeEquivalentTo(expected, options => options.WithStrictOrdering());
    }
}
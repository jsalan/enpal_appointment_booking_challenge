using AppointmentBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppointmentBooking.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<SalesManager> SalesManagers { get; }
    DbSet<Slot> Slots { get; }
}
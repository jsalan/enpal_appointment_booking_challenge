using AppointmentBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentBooking.Infrastructure.Data.Configurations;

public class SlotConfiguration : IEntityTypeConfiguration<Slot>
{
    public void Configure(EntityTypeBuilder<Slot> builder)
    {
        builder.ToTable("slots");

        builder.HasKey(slot => slot.Id);

        builder
            .Property(slot => slot.Id)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(slot => slot.SalesManagerId)
            .HasColumnName("sales_manager_id")
            .IsRequired();

        builder
            .Property(slot => slot.StartDate)
            .HasColumnName("start_date")
            .IsRequired();

        builder
            .Property(slot => slot.EndDate)
            .HasColumnName("end_date")
            .IsRequired();

        builder
            .Property(slot => slot.Booked)
            .HasColumnName("booked")
            .IsRequired();

        builder
            .HasOne<SalesManager>(slot => slot.SalesManager)
            .WithMany(manager => manager.Slots)
            .HasForeignKey(slot => slot.SalesManagerId)
            .IsRequired();
    }
}
using AppointmentBooking.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppointmentBooking.Infrastructure.Data.Configurations;

public class SalesManagerConfiguration : IEntityTypeConfiguration<SalesManager>
{
    public void Configure(EntityTypeBuilder<SalesManager> builder)
    {
        builder.ToTable("sales_managers");

        builder.HasKey(manager => manager.Id);

        builder
            .Property(manager => manager.Id)
            .HasColumnName("id")
            .IsRequired();

        builder
            .Property(manager => manager.Name)
            .HasColumnName("name")
            .IsRequired();

        builder
            .Property(manager => manager.Languages)
            .HasColumnName("languages")
            .HasColumnType("varchar(100)[]");

        builder
            .Property(manager => manager.Products)
            .HasColumnName("products")
            .HasColumnType("varchar(100)[]");

        builder
            .Property(manager => manager.CustomerRatings)
            .HasColumnName("customer_ratings")
            .HasColumnType("varchar(100)[]");
    }
}
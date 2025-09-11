using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class BookingServiceConfiguration : IEntityTypeConfiguration<BookingService>
{
    public void Configure(EntityTypeBuilder<BookingService> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.BookingServices)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(bs => bs.BookingServiceID);

            // Properties
            builder.Property(bs => bs.ServiceID)
                   .IsRequired();

            builder.Property(bs => bs.Quantity)
                   .IsRequired();

            builder.Property(bs => bs.Total)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(bs => bs.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(bs => bs.Booking)
                   .WithMany(b => b.BookingServices)
                   .HasForeignKey(bs => bs.BookingID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(bs => bs.Services)
                   .WithMany()
                   .HasForeignKey(bs => bs.ServiceID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking> 
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Bookings)}");
        if (builder is not null)
        {
            builder.HasKey(x => x.BookingID);

            // Primary key
            builder.HasKey(b => b.BookingID);

            // Properties
            builder.Property(b => b.BookingStatus)
                   .IsRequired()
                   .HasMaxLength(50); 

            builder.Property(b => b.TotalAmount)
                   .HasColumnType("decimal(18,2)");

            builder.Property(b => b.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships

            builder.HasOne(b => b.Guests)
                   .WithMany(g => g.Bookings)
                   .HasForeignKey(b => b.GuestID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.Rooms)
                   .WithMany(r => r.Bookings)
                   .HasForeignKey(b => b.RoomID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(b => b.Payments)
                   .WithOne(p => p.Booking)
                   .HasForeignKey(p => p.BookingID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.BookingServices)
                   .WithOne(bs => bs.Booking)
                   .HasForeignKey(bs => bs.BookingID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

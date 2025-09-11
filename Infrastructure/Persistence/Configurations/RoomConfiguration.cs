using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class RoomConfiguration : IEntityTypeConfiguration<Room>
{
    public void Configure(EntityTypeBuilder<Room> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Rooms)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(r => r.RoomID);

            // Properties
            builder.Property(r => r.RoomNumber)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(r => r.RoomTypeID)
                   .IsRequired();

            builder.Property(r => r.Floor)
                   .IsRequired();

            builder.Property(r => r.Status)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(r => r.PricePerNight)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(r => r.Description)
                   .HasMaxLength(500);

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.UpdatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(r => r.IsBooking)
                   .IsRequired();

            builder.Property(r => r.IsDeleted)
                   .IsRequired();

            // Relationships
            builder.HasOne(r => r.RoomType)
                   .WithMany(rt => rt.Rooms)
                   .HasForeignKey(r => r.RoomTypeID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.FacilityRooms)
                   .WithOne(fr => fr.Room)
                   .HasForeignKey(fr => fr.RoomID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(r => r.Bookings)
                   .WithOne(b => b.Rooms)
                   .HasForeignKey(b => b.RoomID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.ItemUsages)
                   .WithOne(iu => iu.Rooms)
                   .HasForeignKey(iu => iu.RoomID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class GuestConfiguration : IEntityTypeConfiguration<Guest>
{
    public void Configure(EntityTypeBuilder<Guest> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Guests)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(g => g.GuestID);

            // Properties
            builder.Property(g => g.FullName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(g => g.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(g => g.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(g => g.Address)
                   .HasMaxLength(250);

            builder.Property(g => g.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(g => g.Users)
                   .WithMany(u => u.Guests)
                   .HasForeignKey(g => g.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(g => g.Bookings)
                   .WithOne(b => b.Guests)
                   .HasForeignKey(b => b.GuestID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Payments;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
{
    public void Configure(EntityTypeBuilder<Payment> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Payments)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(p => p.PaymentID);

            // Properties
            builder.Property(p => p.AmountPaid)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.PaymentDate)
                   .IsRequired();

            builder.Property(p => p.PaymentMethod)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(p => p.Booking)
                   .WithMany(b => b.Payments)
                   .HasForeignKey(p => p.BookingID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

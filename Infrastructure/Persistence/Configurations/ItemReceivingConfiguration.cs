using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class ItemReceivingConfiguration : IEntityTypeConfiguration<ItemReceiving>
{
    public void Configure(EntityTypeBuilder<ItemReceiving> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.ItemReceivings)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(r => r.ReceiveID);

            // Properties
            builder.Property(r => r.ItemID)
                   .IsRequired();

            builder.Property(r => r.QuantityReceived)
                   .IsRequired();

            builder.Property(r => r.SupplierID)
                   .IsRequired();

            builder.Property(r => r.ReceivedBy)
                   .IsRequired();

            builder.Property(r => r.ReceiveDate)
                   .IsRequired();

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(r => r.InventoryItem)
                   .WithMany(i => i.ItemReceivings)
                   .HasForeignKey(r => r.ItemID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.Suppliers)
                   .WithMany()
                   .HasForeignKey(r => r.SupplierID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(r => r.ReceivedByUsers)
                   .WithMany()
                   .HasForeignKey(r => r.ReceivedBy)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

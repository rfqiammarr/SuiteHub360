using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class InventoryItemConfiguration : IEntityTypeConfiguration<InventoryItem>
{
    public void Configure(EntityTypeBuilder<InventoryItem> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.InventoryItems)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(i => i.ItemID);

            // Properties
            builder.Property(i => i.ItemName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(i => i.CategoryID)
                   .IsRequired();

            builder.Property(i => i.UnitID)
                   .IsRequired();

            builder.Property(i => i.ReorderLevel)
                   .IsRequired();

            builder.Property(i => i.SupplierID)
                   .IsRequired();

            builder.Property(i => i.IsActive)
                   .IsRequired();

            builder.Property(i => i.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(i => i.Categorys)
                   .WithMany()
                   .HasForeignKey(i => i.CategoryID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Units)
                   .WithMany()
                   .HasForeignKey(i => i.UnitID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(i => i.Suppliers)
                   .WithMany()
                   .HasForeignKey(i => i.SupplierID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(i => i.Stocks)
                   .WithOne(s => s.InventoryItem)
                   .HasForeignKey(s => s.ItemID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.ItemUsages)
                   .WithOne(u => u.InventoryItem)
                   .HasForeignKey(u => u.ItemID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(i => i.ItemReceivings)
                   .WithOne(r => r.InventoryItem)
                   .HasForeignKey(r => r.ItemID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

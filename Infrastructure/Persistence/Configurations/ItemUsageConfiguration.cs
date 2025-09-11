using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class ItemUsageConfiguration : IEntityTypeConfiguration<ItemUsage>
{
    public void Configure(EntityTypeBuilder<ItemUsage> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.ItemUsages)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(u => u.UsageID);

            // Properties
            builder.Property(u => u.ItemID)
                   .IsRequired();

            builder.Property(u => u.UsedBy)
                   .IsRequired();

            builder.Property(u => u.RoomID)
                   .IsRequired();

            builder.Property(u => u.QuantityUsed)
                   .IsRequired();

            builder.Property(u => u.UsageDate)
                   .IsRequired();

            builder.Property(u => u.Notes)
                   .HasMaxLength(500);

            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(u => u.InventoryItem)
                   .WithMany(i => i.ItemUsages)
                   .HasForeignKey(u => u.ItemID)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(u => u.UsedByUsers)
                   .WithMany()
                   .HasForeignKey(u => u.UsedBy)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Rooms)
                   .WithMany()
                   .HasForeignKey(u => u.RoomID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

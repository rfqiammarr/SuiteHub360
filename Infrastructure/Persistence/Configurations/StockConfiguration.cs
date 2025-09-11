using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class StockConfiguration : IEntityTypeConfiguration<Stock>
{
    public void Configure(EntityTypeBuilder<Stock> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Stocks)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(s => s.StockID);

            // Properties
            builder.Property(s => s.ItemID)
                   .IsRequired();

            builder.Property(s => s.Location)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(s => s.Quantity)
                   .IsRequired();

            builder.Property(s => s.LastUpdated)
                   .IsRequired();

            builder.Property(s => s.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(s => s.InventoryItem)
                   .WithMany(i => i.Stocks)
                   .HasForeignKey(s => s.ItemID)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

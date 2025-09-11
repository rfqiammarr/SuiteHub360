using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class ItemUnitConfiguration : IEntityTypeConfiguration<ItemUnit>
{
    public void Configure(EntityTypeBuilder<ItemUnit> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.ItemUnits)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(u => u.UnitID);

            // Properties
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Relationships
            builder.HasMany(u => u.InventoryItems)
                   .WithOne(i => i.Units)
                   .HasForeignKey(i => i.UnitID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

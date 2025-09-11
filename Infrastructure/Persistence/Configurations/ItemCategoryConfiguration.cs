using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class ItemCategoryConfiguration : IEntityTypeConfiguration<ItemCategory>
{
    public void Configure(EntityTypeBuilder<ItemCategory> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.ItemCategories)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(c => c.CategoryID);

            // Properties
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Relationships
            builder.HasMany(c => c.InventoryItems)
                   .WithOne(i => i.Categorys)
                   .HasForeignKey(i => i.CategoryID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

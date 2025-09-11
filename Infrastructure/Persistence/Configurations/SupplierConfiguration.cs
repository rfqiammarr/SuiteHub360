using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class SupplierConfiguration : IEntityTypeConfiguration<Supplier>
{
    public void Configure(EntityTypeBuilder<Supplier> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Suppliers)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(s => s.SupplierID);

            // Properties
            builder.Property(s => s.SupplierName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.Phone)
                   .HasMaxLength(20);

            builder.Property(s => s.Email)
                   .HasMaxLength(100);

            builder.Property(s => s.Address)
                   .HasMaxLength(250);

            builder.Property(s => s.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasMany(s => s.InventoryItems)
                   .WithOne(i => i.Suppliers)
                   .HasForeignKey(i => i.SupplierID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(s => s.ItemReceivings)
                   .WithOne(ir => ir.Suppliers)
                   .HasForeignKey(ir => ir.SupplierID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Services)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(s => s.ServiceID);

            // Properties
            builder.Property(s => s.Name)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(s => s.Description)
                   .HasMaxLength(500);

            builder.Property(s => s.Price)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(s => s.CreatedAt) 
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(s => s.IsDeleted)
                   .IsRequired();

            // Relationships
            builder.HasMany(s => s.BookingServices)
                   .WithOne(bs => bs.Services)
                   .HasForeignKey(bs => bs.ServiceID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

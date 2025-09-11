using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Roles)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(r => r.RoleId);

            // Properties
            builder.Property(r => r.RoleName)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(r => r.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasMany(r => r.Users)
                   .WithOne(u => u.Role)
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

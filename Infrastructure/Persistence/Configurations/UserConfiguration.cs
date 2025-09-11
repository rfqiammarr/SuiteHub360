using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.UsersDatas)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(u => u.UserID);

            // Properties
            builder.Property(u => u.Username)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(u => u.PasswordHash)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(u => u.IsActive)
                   .IsRequired();

            builder.Property(u => u.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.Modified)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.IsDeleted)
                   .IsRequired();

            // Relationships
            builder.HasOne(u => u.Role)
                   .WithMany(r => r.Users)
                   .HasForeignKey(u => u.RoleId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Guests)
                   .WithOne(g => g.Users)
                   .HasForeignKey(g => g.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.Employees)
                   .WithOne(e => e.Users)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ItemUsages)
                   .WithOne(iu => iu.UsedByUsers)
                   .HasForeignKey(iu => iu.UsedBy)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(u => u.ItemReceivings)
                   .WithOne(ir => ir.ReceivedByUsers)
                   .HasForeignKey(ir => ir.ReceivedBy)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

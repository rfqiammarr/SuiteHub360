using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Employees)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(e => e.EmployeeId);

            // Properties
            builder.Property(e => e.FullName)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(e => e.PhoneNumber)
                   .HasMaxLength(20);

            builder.Property(e => e.Address)
                   .HasMaxLength(250);

            builder.Property(e => e.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            // Relationships
            builder.HasOne(e => e.Users)
                   .WithMany(u => u.Employees)
                   .HasForeignKey(e => e.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

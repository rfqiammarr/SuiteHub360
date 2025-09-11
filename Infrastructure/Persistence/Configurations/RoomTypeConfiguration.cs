using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class RoomTypesConfiguration : IEntityTypeConfiguration<RoomTypes>
{
    public void Configure(EntityTypeBuilder<RoomTypes> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.RoomTypes)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(rt => rt.RoomTypeID);

            // Properties
            builder.Property(rt => rt.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(rt => rt.Description)
                   .HasMaxLength(500);

            builder.Property(rt => rt.Capacity)
                   .IsRequired();

            builder.Property(rt => rt.BasePrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(rt => rt.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(rt => rt.IsDeleted)
                   .IsRequired();

            // Relationships
            builder.HasMany(rt => rt.Rooms)
                   .WithOne(r => r.RoomType)
                   .HasForeignKey(r => r.RoomTypeID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class FacilityConfiguration : IEntityTypeConfiguration<Facility>
{
    public void Configure(EntityTypeBuilder<Facility> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.Facilities)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(f => f.FacilityId);

            // Properties
            builder.Property(f => f.FacilitiesName)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(f => f.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");          

            // Relationships
            builder.HasMany(f => f.RoomFacilities)
                   .WithOne(rf => rf.Facility)
                   .HasForeignKey(rf => rf.FacilityId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Services;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.Configurations;

public class RoomFacilityConfiguration : IEntityTypeConfiguration<RoomFacility>
{
    public void Configure(EntityTypeBuilder<RoomFacility> builder)
    {
        builder.ToTable($"{nameof(ISuiteHub360DbContext.RoomFacilities)}");

        if (builder is not null)
        {
            // Primary Key
            builder.HasKey(rf => rf.FacilityRoomsId);

            // Properties
            builder.Property(rf => rf.CreatedAt)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(rf => rf.IsDeleted)
                   .IsRequired();

            // Relationships
            builder.HasOne(rf => rf.Facility)
                   .WithMany(f => f.RoomFacilities)
                   .HasForeignKey(rf => rf.FacilityId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(rf => rf.Room)
                   .WithMany(r => r.FacilityRooms)
                   .HasForeignKey(rf => rf.RoomID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

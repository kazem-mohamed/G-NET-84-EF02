using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF02;

public class BadgeConfiguration : IEntityTypeConfiguration<Badge>
{
    public void Configure(EntityTypeBuilder<Badge> builder)
    {
        builder.Property(badge => badge.BadgeNumber).IsRequired().HasMaxLength(50);
        builder.HasIndex(badge => badge.BadgeNumber).IsUnique();
        builder.Property(badge => badge.Tier).HasConversion<string>().HasMaxLength(10);

        builder.HasOne(badge => badge.Attendee)
            .WithOne(attendee => attendee.Badge)
            .HasForeignKey<Badge>(badge => badge.AttendeeId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

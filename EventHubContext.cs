using Microsoft.EntityFrameworkCore;

namespace G_NET_84_EF02;

public class EventHubContext(DbContextOptions<EventHubContext> options) : DbContext(options)
{
    public DbSet<Organizer> Organizers => Set<Organizer>();
    public DbSet<OrganizerProfile> OrganizerProfiles => Set<OrganizerProfile>();
    public DbSet<Event> Events => Set<Event>();
    public DbSet<Attendee> Attendees => Set<Attendee>();
    public DbSet<Badge> Badges => Set<Badge>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrganizerProfile>(builder =>
        {
            builder.Property(profile => profile.Biography).HasMaxLength(1_000);
            builder.Property(profile => profile.WebsiteUrl).HasMaxLength(500);
            builder.Property(profile => profile.LogoUrl).HasMaxLength(500);

            builder.HasOne(profile => profile.Organizer)
                .WithOne(organizer => organizer.Profile)
                .HasForeignKey<OrganizerProfile>(profile => profile.OrganizerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.ApplyConfiguration(new EventConfiguration());
        modelBuilder.ApplyConfiguration(new BadgeConfiguration());
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace G_NET_84_EF02;

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.Property(@event => @event.Title).IsRequired().HasMaxLength(200);
        builder.Property(@event => @event.Description).IsRequired().HasMaxLength(2_000);
        builder.Property(@event => @event.StartDate).IsRequired();
        builder.Property(@event => @event.MaxAttendees).IsRequired();

        builder.HasOne(@event => @event.Organizer)
            .WithMany(organizer => organizer.Events)
            .HasForeignKey(@event => @event.OrganizerId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}

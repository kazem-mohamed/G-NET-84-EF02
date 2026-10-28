namespace G_NET_84_EF02;

public class OrganizerProfile
{
    public int Id { get; set; }
    public string? Biography { get; set; }
    public string? WebsiteUrl { get; set; }
    public string? LogoUrl { get; set; }
    public int OrganizerId { get; set; }
    public Organizer Organizer { get; set; } = null!;
}

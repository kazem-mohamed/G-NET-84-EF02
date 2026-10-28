namespace G_NET_84_EF02;

public class Badge
{
    public int Id { get; set; }
    public string BadgeNumber { get; set; } = string.Empty;
    public DateTime IssuedDate { get; set; }
    public BadgeTier Tier { get; set; }
    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;
}

public enum BadgeTier
{
    Standard,
    VIP
}

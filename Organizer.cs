using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G_NET_84_EF02;

[Table("EventOrganizers")]
public class Organizer
{
    public int Id { get; set; }

    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [StringLength(150)]
    public string? CompanyName { get; set; }

    public bool IsVerified { get; set; }

    public OrganizerProfile? Profile { get; set; }
}

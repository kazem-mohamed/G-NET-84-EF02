using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace G_NET_84_EF02;

public class Attendee
{
    public int Id { get; set; }

    [Required, StringLength(150)]
    public string FullName { get; set; } = string.Empty;

    [Required, StringLength(200), EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(150)]
    public string Street { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string City { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Country { get; set; } = string.Empty;

    [Required, StringLength(20), Column("ZipCode")]
    public string PostalCode { get; set; } = string.Empty;

    [NotMapped]
    public string FullAddress => $"{Street}, {City}, {Country}, {PostalCode}";
}

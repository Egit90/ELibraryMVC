using System.ComponentModel.DataAnnotations;

namespace ELibrary.Models;

public sealed class Company
{
    public Guid Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? PhoneNumber { get; set; }
}
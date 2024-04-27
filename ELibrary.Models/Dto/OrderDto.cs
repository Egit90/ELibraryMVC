namespace ELibrary.Models.Dto;

public sealed class OrderDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;
    public string? PhoneNumber { get; set; } = null!;
    public string? Email { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public double Total { get; set; }

}
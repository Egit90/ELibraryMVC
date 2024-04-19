namespace ELibrary.Models.Dto;

public sealed class ProductDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public int Id { get; set; }
}
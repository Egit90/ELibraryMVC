namespace ELibrary.Models.Dto;

public sealed class ProductDto
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Author { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
    public string? ImageUrl { get; set; }
    public double ListPrice { get; set; }
    public double Price { get; set; }
    public double Price50 { get; set; }
    public double Price100 { get; set; }
    public string ISBN { get; set; } = null!;
    public int Id { get; set; }
    public Guid ShoppingCartId { get; set; }
    public int Count { get; set; }
}
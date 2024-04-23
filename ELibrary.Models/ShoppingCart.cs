namespace ELibrary.Models;

public sealed class ShoppingCart
{
    public Guid Id { get; set; }
    public int Count { get; set; }

    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;

    public string ApplicationUserId { get; set; } = null!;
    public ApplicationUser ApplicationUser { get; set; } = null!;
}
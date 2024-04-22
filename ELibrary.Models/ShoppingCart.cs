namespace ELibrary.Models;

public sealed class ShoppingCart
{
    public Guid Id { get; set; }
    public Product Product { get; set; }
    public int Count { get; set; }
    public ApplicationUser ApplicationUser { get; set; }
}
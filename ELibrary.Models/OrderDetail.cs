namespace ELibrary.Models;

public sealed class OrderDetail
{
    public Guid Id { get; set; }

    public Guid OrderHeaderId { get; set; }
    public OrderHeader OrderHeader { get; set; }


    public int ProductId { get; set; }
    public Product Product { get; set; }

    public int Count { get; set; }
    public double Price { get; set; }

}
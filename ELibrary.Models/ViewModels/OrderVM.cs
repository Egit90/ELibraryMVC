namespace ELibrary.Models.ViewModels;

public sealed class OrderVM
{
    public OrderHeader OrderHeader { get; set; }
    public IEnumerable<OrderDetail> OrderDetails { get; set; }

}
using ELibrary.Models.Dto;
using ELibrary.Models.ViewModels;

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


    public static List<OrderDetail> CreateOrderDetail(ShoppingCartVM shoppingCartVM, Guid OrderHeaderId)
    {
        List<OrderDetail> newList = [];

        foreach (ProductDto product in shoppingCartVM.ShoppingCartList)
        {
            newList.Add(new OrderDetail
            {
                ProductId = product.Id,
                OrderHeaderId = OrderHeaderId,
                Price = ShoppingCartVM.GetItemPriceBasedOnQty(product.Count, product.Price, product.Price50, product.Price100),
                Count = product.Count
            });
        }
        return newList;
    }
}
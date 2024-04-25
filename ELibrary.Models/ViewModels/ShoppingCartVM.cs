using ELibrary.Models.Dto;

namespace ELibrary.Models.ViewModels;

public sealed class ShoppingCartVM
{

    public IEnumerable<ProductDto> ShoppingCartList { get; set; }
    public double OrderTotal
    {
        get
        {
            double s = 0;
            foreach (var item in ShoppingCartList)
            {
                s += GetItemPriceBasedOnQty(item.Count, item.Price, item.Price50, item.Price100);
            }
            return s;
        }
    }

    public static double GetItemPriceBasedOnQty(int count, double Price, double Price50, double Price100) => count switch
    {
        0 => 0,
        <= 50 => Price * count,
        <= 100 => Price50 * count,
        _ => Price100 * count
    };
}
using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public sealed class ShoppingCartRepository(DataContext dataContext) : Repository<ShoppingCart>(dataContext), IShoppingCartRepository
{
    public void Update(ShoppingCart shoppingCart)
    {
        _dataContext.ShoppingCarts.Update(shoppingCart);
    }
}
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart shoppingCart);
}
using ELibrary.Models;
using ELibrary.Models.Dto;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart shoppingCart);
    Task<IEnumerable<ProductDto>> GetShoppingCartItemsByCustomer(string CustomerId);
}
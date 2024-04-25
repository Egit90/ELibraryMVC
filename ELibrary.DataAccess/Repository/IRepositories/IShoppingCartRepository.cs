using ELibrary.Models;
using ELibrary.Models.Dto;
using ELibrary.Models.ViewModels;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IShoppingCartRepository : IRepository<ShoppingCart>
{
    void Update(ShoppingCart shoppingCart);
    Task<ShoppingCartVM> GetShoppingCartItemsByCustomer(string CustomerId);
}
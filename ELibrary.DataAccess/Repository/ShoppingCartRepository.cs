using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public sealed class ShoppingCartRepository(DataContext dataContext) : Repository<ShoppingCart>(dataContext), IShoppingCartRepository
{
    public async Task<IEnumerable<ProductDto>> GetShoppingCartItemsByCustomer(string CustomerId)
    {
        return await _dataContext.ShoppingCarts.Where(c => c.ApplicationUserId == CustomerId).Select(o => new ProductDto
        {
            ShoppingCartId = o.Id,
            Author = o.Product.Author,
            CategoryName = o.Product.Category.Name,
            Description = o.Product.Description,
            Title = o.Product.Title,
            ListPrice = o.Product.ListPrice,
            Price = o.Product.Price,
            Price100 = o.Product.Price100,
            Price50 = o.Product.Price50,
            ImageUrl = o.Product.ImageUrl
        }).ToListAsync();
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _dataContext.ShoppingCarts.Update(shoppingCart);
    }
}
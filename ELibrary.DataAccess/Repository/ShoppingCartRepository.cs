using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.Dto;
using ELibrary.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public sealed class ShoppingCartRepository(DataContext dataContext) : Repository<ShoppingCart>(dataContext), IShoppingCartRepository
{

    public async Task<IEnumerable<ShoppingCart>> GetAllCartItems(string CustomerId)
    {
        ApplicationUser? user = await _dataContext.ApplicationUsers.FindAsync(CustomerId)
                                ?? throw new InvalidOperationException($"ApplicationUser with ID {CustomerId} not found.");


        return await _dataContext.ShoppingCarts.Where(c => c.ApplicationUserId == CustomerId).ToListAsync();
    }


    public async Task<ShoppingCartVM> GetShoppingCartItemsByCustomer(string CustomerId)
    {

        ApplicationUser? user = await _dataContext.ApplicationUsers.FindAsync(CustomerId)
                                ?? throw new InvalidOperationException($"ApplicationUser with ID {CustomerId} not found.");

        var shoppingCartItems = await _dataContext.ShoppingCarts
            .Where(c => c.ApplicationUserId == CustomerId)
            .Select(o => new ProductDto
            {
                ShoppingCartId = o.Id,
                Id = o.ProductId,
                Author = o.Product.Author,
                CategoryName = o.Product.Category.Name,
                Description = o.Product.Description,
                Title = o.Product.Title,
                ListPrice = o.Product.ListPrice,
                Price = o.Product.Price,
                Price100 = o.Product.Price100,
                Price50 = o.Product.Price50,
                ImageUrl = o.Product.ImageUrl,
                Count = o.Count,
            }).ToListAsync();

        var orderHeader = new OrderHeader
        {
            ApplicationUserId = CustomerId,
        };

        orderHeader.PopulateFromApplicationUser(user);

        return new ShoppingCartVM
        {
            ShoppingCartList = shoppingCartItems,
            OrderHeader = orderHeader
        };

    }

    public async void RemoveShoppingCart(string CustomerId)
    {
        var ItemsToDelete = await _dataContext.ShoppingCarts.Where(c => c.ApplicationUserId == CustomerId).ToListAsync();
        _dataContext.ShoppingCarts.RemoveRange(ItemsToDelete);


    }

    public void Update(ShoppingCart shoppingCart)
    {
        _dataContext.ShoppingCarts.Update(shoppingCart);
    }
}
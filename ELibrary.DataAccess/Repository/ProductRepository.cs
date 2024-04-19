using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public class ProductRepository(DataContext dataContext) : Repository<Product>(dataContext), IProductRepository
{
    public async Task<IEnumerable<ProductDto>> GetListOfProductDtoAsync()
    {
        return await _dataContext.Products
                                .Select(o => new ProductDto
                                {
                                    Id = o.Id,
                                    Author = o.Author,
                                    CategoryName = o.Category.Name,
                                    Description = o.Description,
                                    Title = o.Title,
                                    ListPrice = o.ListPrice,
                                    Price = o.Price,
                                    Price100 = o.Price100,
                                    Price50 = o.Price50,
                                    ImageUrl = o.ImageUrl
                                })
                                .ToListAsync();
    }

    public async Task<ProductDto?> GetProductDtoAsync(int id)
    {

        return await _dataContext.Products
                                .Select(o => new ProductDto
                                {
                                    Id = o.Id,
                                    Author = o.Author,
                                    CategoryName = o.Category.Name,
                                    Description = o.Description,
                                    Title = o.Title,
                                    ListPrice = o.ListPrice,
                                    Price = o.Price,
                                    Price100 = o.Price100,
                                    Price50 = o.Price50,
                                    ISBN = o.ISBN,
                                    ImageUrl = o.ImageUrl
                                })
                                .Where(x => x.Id == id)
                                .FirstOrDefaultAsync();
    }

    public void Update(Product product)
    {
        _dataContext.Products.Update(product); ;
    }
}
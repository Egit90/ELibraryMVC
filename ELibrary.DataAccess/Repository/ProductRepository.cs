using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public class ProductRepository(DataContext dataContext) : Repository<Product>(dataContext), IProductRepository
{
    public async Task<IEnumerable<ProductDto>> GetProductDtoList()
    {
        return await _dataContext.Products
                                .Select(o => new ProductDto
                                {
                                    Id = o.Id,
                                    Author = o.Author,
                                    CategoryName = o.Category.Name,
                                    Description = o.Description,
                                    Title = o.Title,
                                })
                                .ToListAsync();
    }

    public void Update(Product product)
    {
        _dataContext.Products.Update(product); ;
    }
}
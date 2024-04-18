using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public class ProductRepository(DataContext dataContext) : Repository<Product>(dataContext), IProductRepository
{
    public async Task<IEnumerable<Product>> GetProductsWithCategoryName()
    {
        return await _dataContext.Products
                                .Include(x => x.Category)
                                .ToListAsync();
    }

    public void Update(Product product)
    {
        _dataContext.Products.Update(product); ;
    }
}
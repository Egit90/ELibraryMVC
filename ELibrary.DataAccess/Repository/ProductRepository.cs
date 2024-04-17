using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public class ProductRepository(DataContext dataContext) : Repository<Product>(dataContext), IProductRepository
{
    public void Update(Product product)
    {
        _dataContext.Products.Update(product); ;
    }
}
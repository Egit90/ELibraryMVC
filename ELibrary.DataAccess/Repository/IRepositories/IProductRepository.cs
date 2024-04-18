using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
    Task<IEnumerable<Product>> GetProductsWithCategoryName();
}
using ELibrary.Models;
using ELibrary.Models.Dto;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IProductRepository : IRepository<Product>
{
    void Update(Product product);
    Task<IEnumerable<ProductDto>> GetProductDtoList();
}
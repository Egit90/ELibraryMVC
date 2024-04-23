using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface ICategoryRepository : IRepository<Category>
{
    void Update(Category category);
}

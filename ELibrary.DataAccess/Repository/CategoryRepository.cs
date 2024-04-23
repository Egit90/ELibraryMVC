using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public sealed class CategoryRepository(DataContext dataContext) : Repository<Category>(dataContext), ICategoryRepository
{
    public void Update(Category category)
    {
        _dataContext.Categories.Update(category);
    }
}

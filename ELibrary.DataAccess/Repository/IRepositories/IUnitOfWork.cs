namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }

    Task SaveAsync();
}
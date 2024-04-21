namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }
    ICompanyRepository Company { get; }
    Task SaveAsync();
}
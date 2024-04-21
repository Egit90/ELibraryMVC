using System.Linq.Expressions;
using ELibrary.DataAccess.Data;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public class UnitOfWork(DataContext dataContext) : IUnitOfWork
{
    private readonly DataContext _dataContext = dataContext;

    public ICategoryRepository Category => new CategoryRepository(_dataContext);
    public IProductRepository Product => new ProductRepository(_dataContext);
    public ICompanyRepository Company => new CompanyRepository(_dataContext);

    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}


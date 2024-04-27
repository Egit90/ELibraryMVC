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
    public IShoppingCartRepository ShoppingCart => new ShoppingCartRepository(_dataContext);

    public IApplicationUserRepository ApplicationUser => new ApplicationUserRepository(_dataContext);

    public IOrderDetailRepository OrderDetail => new OrderDetailRepository(_dataContext);

    public IOrderHeaderRepository OrderHeader => new OrderHeaderRepository(_dataContext);

    public async Task SaveAsync()
    {
        await _dataContext.SaveChangesAsync();
    }
}


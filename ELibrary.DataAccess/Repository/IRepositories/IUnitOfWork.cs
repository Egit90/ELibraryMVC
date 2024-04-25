namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IUnitOfWork
{
    ICategoryRepository Category { get; }
    IProductRepository Product { get; }
    ICompanyRepository Company { get; }
    IShoppingCartRepository ShoppingCart { get; }
    IApplicationUserRepository ApplicationUserRepository { get; }
    IOrderDetailRepository OrderDetailRepository { get; }
    IOrderHeaderRepository OrderHeaderRepository { get; }
    Task SaveAsync();
}
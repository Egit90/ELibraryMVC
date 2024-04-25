using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public sealed class OrderHeaderRepository(DataContext dataContext) : Repository<OrderHeader>(dataContext), IOrderHeaderRepository
{
    public void Update(OrderHeader OrderHeader)
    {
        _dataContext.OrderHeaders.Update(OrderHeader);
    }
}

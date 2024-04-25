using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;

namespace ELibrary.DataAccess.Repository;

public sealed class OrderDetailRepository(DataContext dataContext) : Repository<OrderDetail>(dataContext), IOrderDetailRepository
{

    public void Update(OrderDetail OrderDetail)
    {
        _dataContext.OrderDetails.Update(OrderDetail);
    }
}
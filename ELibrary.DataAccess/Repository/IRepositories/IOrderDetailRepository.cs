using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IOrderDetailRepository : IRepository<OrderDetail>
{
    void Update(OrderDetail OrderDetail);
}
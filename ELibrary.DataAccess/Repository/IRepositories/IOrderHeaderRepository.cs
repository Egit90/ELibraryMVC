using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IOrderHeaderRepository : IRepository<OrderHeader>
{
    void Update(OrderHeader OrderHeader);
}

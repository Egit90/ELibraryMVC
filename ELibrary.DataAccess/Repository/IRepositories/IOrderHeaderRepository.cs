using ELibrary.Models;
using ELibrary.Models.Dto;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IOrderHeaderRepository : IRepository<OrderHeader>
{
    void Update(OrderHeader OrderHeader);
    Task<List<OrderDto>> GetOrdersDto();
    void UpdateStatus(Guid id, string orderStatus, string? PaymentStatus = null);
    void UpdateStripePaymentID(Guid id, string sessionID, string PaymentIntentOd);
}

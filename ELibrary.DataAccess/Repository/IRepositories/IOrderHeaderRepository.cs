using ELibrary.Models;

namespace ELibrary.DataAccess.Repository.IRepositories;

public interface IOrderHeaderRepository : IRepository<OrderHeader>
{
    void Update(OrderHeader OrderHeader);
    void UpdateStatus(Guid id, string orderStatus, string? PaymentStatus = null);
    void UpdateStripePaymentID(Guid id, string sessionID, string PaymentIntentOd);
}

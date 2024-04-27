using ELibrary.DataAccess.Data;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace ELibrary.DataAccess.Repository;

public sealed class OrderHeaderRepository(DataContext dataContext) : Repository<OrderHeader>(dataContext), IOrderHeaderRepository
{
    public async Task<List<OrderDto>> GetOrdersDto()
    {
        return await _dataContext.OrderHeaders.Select(v => new OrderDto
        {
            Id = v.Id,
            Name = v.ApplicationUser.Name,
            Email = v.ApplicationUser.Email,
            PhoneNumber = v.ApplicationUser.PhoneNumber,
            Status = v.PaymentStatus,
            Total = v.OrderTotal,
        }).ToListAsync();
    }

    public void Update(OrderHeader OrderHeader)
    {
        _dataContext.OrderHeaders.Update(OrderHeader);
    }

    public void UpdateStatus(Guid id, string orderStatus, string? PaymentStatus = null)
    {
        var orderFromDb = _dataContext.OrderHeaders.FirstOrDefault(u => u.Id == id);
        if (orderFromDb != null)
        {
            orderFromDb.OrderStatus = orderStatus;
            if (!string.IsNullOrEmpty(PaymentStatus))
            {
                orderFromDb.PaymentStatus = PaymentStatus;
            }
        }
    }

    public void UpdateStripePaymentID(Guid id, string sessionID, string PaymentIntentOd)
    {
        var orderFromDb = _dataContext.OrderHeaders.FirstOrDefault(u => u.Id == id);
        if (!string.IsNullOrEmpty(sessionID))
        {
            orderFromDb.SessionId = sessionID;
        }
        if (!string.IsNullOrEmpty(PaymentIntentOd))
        {
            orderFromDb.PaymentIntentId = PaymentIntentOd;
            orderFromDb.PaymentDate = DateTime.Now;
        }
    }
}

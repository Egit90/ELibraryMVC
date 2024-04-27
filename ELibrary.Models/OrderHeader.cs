using System.ComponentModel.DataAnnotations;

namespace ELibrary.Models;

public sealed class OrderHeader
{
    public Guid Id { get; set; }

    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public DateTime OrderDate { get; set; }
    public DateTime ShippingDate { get; set; }
    public double OrderTotal { get; set; }


    public string? OrderStatus { get; set; }
    public string? PaymentStatus { get; set; }
    public string? TrackingNumber { get; set; }
    public string? Carrier { get; set; }

    public DateTime PaymentDate { get; set; }
    public DateOnly PaymentDateDueDate { get; set; }

    public string? PaymentIntentId { get; set; }

    public string? PhoneNumber { get; set; }
    public string? StreetAddress { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }

    public string? Name { get; set; }



    public void PopulateFromApplicationUser(ApplicationUser user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user), "ApplicationUser cannot be null.");
        }

        PhoneNumber = user.PhoneNumber;
        StreetAddress = user.StreetAddress;
        City = user.City;
        State = user.State;
        PostalCode = user.PostalCode;
        Name = user.Name;
    }
}

using System.Security.Claims;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.ViewModels;
using ELibrary.Utility;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;

namespace ELibrary.Web.Areas.Customer.Controllers;

[Area("Customer")]
[Authorize]
public sealed class CartController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [BindProperty]
    public ShoppingCartVM CartVMProp { get; set; } = new();
    public async Task<IActionResult> Index()
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);

        if (user == null)
        {
            return NotFound();
        }

        var data = await _unitOfWork.ShoppingCart.GetShoppingCartItemsByCustomer(user.Value);
        return View(data);
    }
    public async Task<IActionResult> Summary()
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);

        if (user == null)
        {
            return NotFound();
        }

        CartVMProp = await _unitOfWork.ShoppingCart.GetShoppingCartItemsByCustomer(user.Value);
        return View(CartVMProp);
    }


    [HttpPost]
    [ActionName("Summary")]
    public async Task<IActionResult> SummaryPost()
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);

        if (user == null)
        {
            return NotFound();
        }

        CartVMProp.ShoppingCartList = (await _unitOfWork.ShoppingCart.GetShoppingCartItemsByCustomer(user.Value)).ShoppingCartList;

        // Create ORder Header
        var orderHeader = new OrderHeader();
        orderHeader = CartVMProp.OrderHeader;
        orderHeader.ApplicationUserId = user.Value;

        var ApplicationUser = await _unitOfWork.ApplicationUser.GetAsync(u => u.Id == user.Value);

        if (ApplicationUser!.CompanyId.GetValueOrDefault() == Guid.Empty)
        {
            orderHeader.PaymentStatus = SD.PaymentStatusPending;
            orderHeader.OrderStatus = SD.StatusPending;
        }
        else
        {

            orderHeader.PaymentStatus = SD.PaymentStatusDelayedPayment;
            orderHeader.OrderStatus = SD.StatusApproved;
        }



        await _unitOfWork.OrderHeader.AddAsync(orderHeader);
        await _unitOfWork.SaveAsync();

        // create Order Detail

        var existCart = await _unitOfWork.ShoppingCart.GetShoppingCartItemsByCustomer(user.Value);
        var ds = OrderDetail.CreateOrderDetail(existCart, orderHeader.Id);
        await _unitOfWork.OrderDetail.AddRangeAsync(ds);





        if (ApplicationUser!.CompanyId.GetValueOrDefault() == Guid.Empty)
        {
            //stripe
            var domain = "http://localhost:5290/";

            var options = new Stripe.Checkout.SessionCreateOptions
            {
                SuccessUrl = domain + $"customer/cart/OrderConfirmation?id={orderHeader.Id}",
                CancelUrl = domain + $"customer/cart/index",
                LineItems = [],
                Mode = "payment",
            };

            foreach (var item in existCart.ShoppingCartList)
            {
                var sessionLineItemOptions = new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        UnitAmount = (long)(ShoppingCartVM.GetItemPriceBasedOnQty(item.Count, item.Price, item.Price50, item.Price100) * 100),
                        Currency = "usd",
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = item.Title,
                        }
                    },
                    Quantity = item.Count
                };
                options.LineItems.Add(sessionLineItemOptions);
            }



            var service = new SessionService();
            var session = service.Create(options);

            _unitOfWork.OrderHeader.UpdateStripePaymentID(orderHeader.Id, session.Id, session.PaymentIntentId);
            await _unitOfWork.SaveAsync();

            Response.Headers.Append("Location", session.Url);

            return new StatusCodeResult(303);
        }

        return RedirectToAction(nameof(OrderConfirmation), new { id = orderHeader.Id });
    }


    public async Task<IActionResult> OrderConfirmation(Guid id)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);

        if (user == null)
        {
            return NotFound();
        }

        var orderHeader = await _unitOfWork.OrderHeader.GetAsync(u => u.Id == id);

        if (orderHeader == null)
        {
            return NotFound();
        }

        if (orderHeader.PaymentStatus != SD.PaymentStatusDelayedPayment)
        {
            var service = new SessionService();
            var session = await service.GetAsync(orderHeader.SessionId);
            if (session.PaymentStatus.Equals("paid", StringComparison.CurrentCultureIgnoreCase))
            {
                // update DB Payment is successful
                _unitOfWork.OrderHeader.UpdateStripePaymentID(orderHeader.Id, session.Id, session.PaymentIntentId);
                _unitOfWork.OrderHeader.UpdateStatus(id, SD.StatusApproved, SD.PaymentStatusApproved);
                await _unitOfWork.SaveAsync();

                // Remove cart items
                _unitOfWork.ShoppingCart.RemoveShoppingCart(user.Value);
                await _unitOfWork.SaveAsync();
            }
        }
        return View(id);
    }


    public async Task<IActionResult> Plus(Guid cartId)
    {
        var cartProduct = await _unitOfWork.ShoppingCart.GetAsync(x => x.Id == cartId);

        if (cartProduct == null)
        {
            return NotFound();
        }

        cartProduct.Count++;

        await _unitOfWork.SaveAsync();
        return RedirectToAction(nameof(Index));
    }
    public async Task<IActionResult> Minus(Guid cartId)
    {
        var cartProduct = await _unitOfWork.ShoppingCart.GetAsync(x => x.Id == cartId);

        if (cartProduct == null)
        {
            return NotFound();
        }

        if (cartProduct.Count <= 1)
        {
            _unitOfWork.ShoppingCart.Remove(cartProduct);
        }
        else
        {
            cartProduct.Count--;
        }


        await _unitOfWork.SaveAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Remove(Guid cartId)
    {
        var cartProduct = await _unitOfWork.ShoppingCart.GetAsync(x => x.Id == cartId);

        if (cartProduct == null)
        {
            return NotFound();
        }

        _unitOfWork.ShoppingCart.Remove(cartProduct);

        await _unitOfWork.SaveAsync();
        return RedirectToAction(nameof(Index));
    }
}
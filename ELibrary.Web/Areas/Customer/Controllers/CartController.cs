using System.Security.Claims;
using ELibrary.DataAccess.Repository.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Web.Areas.Customer.Controllers;

public sealed class CartController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    [Area("Customer")]
    [Authorize]
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
}
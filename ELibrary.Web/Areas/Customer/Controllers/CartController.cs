using System.Security.Claims;
using ELibrary.DataAccess.Repository.IRepositories;
using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Web.Areas.Customer.Controllers;

[Area("Customer")]
[Authorize]
public sealed class CartController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


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

        var data = await _unitOfWork.ShoppingCart.GetShoppingCartItemsByCustomer(user.Value);
        return View(data);
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
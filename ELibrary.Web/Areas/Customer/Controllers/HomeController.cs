using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ELibrary.Models;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models.Dto;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ELibrary.Web.Areas.Customer.Controllers;

[Area("Customer")]
public class HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork) : Controller
{
    private readonly ILogger<HomeController> _logger = logger;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IActionResult> Index()
    {
        var product = await _unitOfWork.Product.GetListOfProductDtoAsync();
        return View(product);
    }

    public async Task<IActionResult> Detail(int id)
    {
        var product = await _unitOfWork.Product.GetProductDtoAsync(id);
        return View(product);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Detail(ProductDto product)
    {
        var user = User.FindFirst(ClaimTypes.NameIdentifier);

        if (user == null)
        {
            return NotFound();
        }

        var existCart = await _unitOfWork.ShoppingCart.GetAsync(x => x.ApplicationUserId == user.Value.ToString() && x.ProductId == product.Id);

        // Shopping Cart Exist
        if (existCart != null)
        {
            existCart.Count += product.Count;
        }
        else
        {
            await _unitOfWork.ShoppingCart.AddAsync(new ShoppingCart
            {
                ApplicationUserId = user.Value,
                Count = product.Count,
                ProductId = product.Id
            });
        }
        await _unitOfWork.SaveAsync();
        return RedirectToAction(nameof(Index));
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

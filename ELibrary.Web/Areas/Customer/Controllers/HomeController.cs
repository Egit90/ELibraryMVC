using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ELibrary.Models;
using ELibrary.DataAccess.Repository.IRepositories;

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

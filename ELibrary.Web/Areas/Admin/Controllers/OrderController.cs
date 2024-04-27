using ELibrary.DataAccess.Repository.IRepositories;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Web.Areas.Admin.Controllers;

[Area("Admin")]
public class OrderController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    public IActionResult Index()
    {
        return View();
    }

    #region API Calls

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dataList = await _unitOfWork.OrderHeader.GetOrdersDto();
        return Json(new { data = dataList });
    }


    #endregion

}
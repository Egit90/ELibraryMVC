using System.Text.Json;
using System.Text.Json.Serialization;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.ViewModels;
using ELibrary.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELibrary.Web.Areas.Admin.Controllers;


[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CompanyController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<IActionResult> Index()
    {
        var data = await _unitOfWork.Company.GetAllAsync();
        return View(data);
    }


    public async Task<IActionResult> Upsert(Guid? id)
    {

        Company Company = String.IsNullOrEmpty(id.ToString()) ? new() : await _unitOfWork.Company.GetAsync(x => x.Id == id) ?? new();
        return View(Company);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(Company company)
    {

        if (!ModelState.IsValid)
        {
            return View(company);
        }


        if (String.IsNullOrEmpty(company.Id.ToString()))
        {
            await _unitOfWork.Company.AddAsync(company);
        }
        else
        {
            _unitOfWork.Company.Update(company);
        }
        await _unitOfWork.SaveAsync();
        TempData["Success"] = "Company was created successfully";
        return RedirectToAction("Index");
    }

    #region API Calls

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dataList = await _unitOfWork.Company.GetAllAsync();

        return Json(new { data = dataList });

    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid? Id)
    {
        var CompanyToDelete = await _unitOfWork.Company.GetAsync(u => u.Id == Id);

        if (CompanyToDelete == null)
        {
            return Json(new { success = false, message = "error while deleting" });
        }

        _unitOfWork.Company.Remove(CompanyToDelete);
        await _unitOfWork.SaveAsync();
        return Json(new { success = true, message = "delete was successful" });
    }
    #endregion

}
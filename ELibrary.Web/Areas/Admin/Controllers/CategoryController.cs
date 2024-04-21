using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ELibrary.Web.Areas.Admin.Controllers;

[Area("Admin")]
[Authorize(Roles = SD.Role_Admin)]
public class CategoryController(ILogger<CategoryController> logger, IUnitOfWork unitOfWork) : Controller
{
    private readonly ILogger<CategoryController> _logger = logger;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<IActionResult> Index()
    {
        var data = await _unitOfWork.Category.GetAllAsync();
        return View(data);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        await _unitOfWork.Category.AddAsync(category);
        await _unitOfWork.SaveAsync();


        TempData["Success"] = "Category was created successfully";
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Edit(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }

        var res = await _unitOfWork.Category.GetAsync(u => u.Id == Id);


        if (res == null)
        {
            return NotFound();
        }

        return View(res);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        _unitOfWork.Category.Update(category);
        await _unitOfWork.SaveAsync();
        TempData["Success"] = "Category was altered successfully";
        return RedirectToAction("Index");
    }



    public async Task<IActionResult> Delete(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }

        var res = await _unitOfWork.Category.GetAsync(u => u.Id == Id);

        if (res == null)
        {
            return NotFound();
        }

        return View(res);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int? Id)
    {
        var cat = await _unitOfWork.Category.GetAsync(u => u.Id == Id);

        if (cat == null)
        {
            return NotFound();
        }

        _unitOfWork.Category.Remove(cat);
        await _unitOfWork.SaveAsync();
        TempData["Success"] = "Category was deleted successfully";
        return RedirectToAction("Index");
    }

}
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELibrary.Web.Areas.Admin.Controllers;


[Area("Admin")]
public class ProductController(IUnitOfWork unitOfWork) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;


    public async Task<IActionResult> Index()
    {
        var data = await _unitOfWork.Product.GetProductsWithCategoryName();

        Console.WriteLine("******************************************************************** \n", data, "******************************************************************** \n");


        return View(data);
    }


    public async Task<IActionResult> Create()
    {
        var Cat = await _unitOfWork.Category.GetAllAsync();
        IEnumerable<SelectListItem> CatList = Cat.Select(u => new SelectListItem
        {
            Text = u.Name,
            Value = u.Id.ToString()
        });
        ViewBag.CategoryList = CatList;
        return View(new ProductVM { Product = new Product(), CategoryList = CatList });
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product product)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        await _unitOfWork.Product.AddAsync(product);
        await _unitOfWork.SaveAsync();


        TempData["Success"] = "product was created successfully";
        return RedirectToAction("Index");
    }


    public async Task<IActionResult> Edit(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }

        var res = await _unitOfWork.Product.GetAsync(u => u.Id == Id);


        if (res == null)
        {
            return NotFound();
        }

        return View(res);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Product product)
    {

        if (!ModelState.IsValid)
        {
            return View();
        }

        _unitOfWork.Product.Update(product);
        await _unitOfWork.SaveAsync();
        TempData["Success"] = "Product was altered successfully";
        return RedirectToAction("Index");
    }



    public async Task<IActionResult> Delete(int? Id)
    {
        if (Id == null || Id == 0)
        {
            return NotFound();
        }

        var res = await _unitOfWork.Product.GetAsync(u => u.Id == Id);

        if (res == null)
        {
            return NotFound();
        }

        return View(res);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeletePost(int? Id)
    {
        var cat = await _unitOfWork.Product.GetAsync(u => u.Id == Id);

        if (cat == null)
        {
            return NotFound();
        }

        _unitOfWork.Product.Remove(cat);
        await _unitOfWork.SaveAsync();
        TempData["Success"] = "Product was deleted successfully";
        return RedirectToAction("Index");
    }


}
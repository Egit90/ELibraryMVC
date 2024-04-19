using System.Text.Json;
using System.Text.Json.Serialization;
using ELibrary.DataAccess.Repository.IRepositories;
using ELibrary.Models;
using ELibrary.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELibrary.Web.Areas.Admin.Controllers;


[Area("Admin")]
public class ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment) : Controller
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment;

    public async Task<IActionResult> Index()
    {
        var data = await _unitOfWork.Product.GetProductDtoList();

        return View(data);
    }


    public async Task<IActionResult> Upsert(int? id)
    {
        var Cat = await _unitOfWork.Category.GetAllAsync();

        ProductVM productVM = new()
        {
            CategoryList = Cat.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            }),
            Product = new Product()
        };

        if (id == null || id == 0)
        {
            return View(productVM);
        }

        productVM.Product = await _unitOfWork.Product.GetAsync(x => x.Id == id)
                            ?? new Product();

        return View(productVM);
    }

    [HttpPost]
    public async Task<IActionResult> Upsert(ProductVM productVM, IFormFile? file)
    {

        if (!ModelState.IsValid)
        {
            var Cat = await _unitOfWork.Category.GetAllAsync();
            IEnumerable<SelectListItem> CatList = Cat.Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            productVM.CategoryList = CatList;
            return View(productVM);
        }

        if (file != null)
        {
            string wwwRootPath = _webHostEnvironment.WebRootPath;
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            string productPath = Path.Combine(wwwRootPath, "images", "product");

            if (!string.IsNullOrEmpty(productVM.Product.ImageUrl))
            {
                // Delete old Image 
                var oldImagePath = Path.Combine(wwwRootPath, productVM.Product.ImageUrl.TrimStart('/'));

                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
            {
                file.CopyTo(fileStream);
            }

            productVM.Product.ImageUrl = Path.Combine("/images", "product", fileName);

        }

        if (productVM.Product.Id == 0)
        {
            await _unitOfWork.Product.AddAsync(productVM.Product);
        }
        else
        {
            _unitOfWork.Product.Update(productVM.Product);
        }



        await _unitOfWork.SaveAsync();


        TempData["Success"] = "product was created successfully";
        return RedirectToAction("Index");
    }



    #region API Calls

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dataList = await _unitOfWork.Product.GetProductDtoList();

        return Json(new { data = dataList });

    }

    [HttpDelete]
    public async Task<IActionResult> Delete(int? Id)
    {
        var productToDelete = await _unitOfWork.Product.GetAsync(u => u.Id == Id);

        if (productToDelete == null)
        {
            return Json(new { success = false, message = "error while deleting" });
        }

        if (productToDelete.ImageUrl != null)
        {

            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, productToDelete.ImageUrl.TrimStart('/'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
        }


        _unitOfWork.Product.Remove(productToDelete);
        await _unitOfWork.SaveAsync();
        return Json(new { success = true, message = "delete was successful" });
    }
    #endregion

}
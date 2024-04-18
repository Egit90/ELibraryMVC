using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ELibrary.Models.ViewModels;

public sealed class ProductVM
{
    public Product Product { get; set; } = null!;

    [ValidateNever]
    public IEnumerable<SelectListItem> CategoryList { get; set; } = [];
}
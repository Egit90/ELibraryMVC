using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ELibrary.Models;

public sealed class Category
{
    public int Id { get; set; }

    [DisplayName("Category Name")]
    [MaxLength(30)]
    [Required]
    public string Name { get; set; } = null!;

    [DisplayName("Display Order")]
    [Range(1, 1000)]

    public int DisplayOrder { get; set; }

    public List<Product> Products { get; set; } = null!;
}
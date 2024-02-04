using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int productId { get; set; }
    [Required(ErrorMessage ="ProductName is required")]
    public String productName { get; set; } = String.Empty;
    [Required(ErrorMessage ="Price is required")]
    public decimal price { get; set; }
    public int? CategoryId {get;set;}
    public Category? category {get;set;}
}

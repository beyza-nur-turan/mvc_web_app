using System.ComponentModel.DataAnnotations;

namespace Entities.Models;
public class Product
{
    public int productId { get; set; }
    
    public String productName { get; set; } = String.Empty;
    
    public decimal price { get; set; }
    public int? CategoryId {get;set;}
    public Category? category {get;set;}
}

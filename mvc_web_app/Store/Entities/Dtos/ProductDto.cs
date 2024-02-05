using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        //immutable olacakları için set yerine init yazıyoruz. bir kez tanımladıktan sonra değiştiremeyiz
         public int productId { get; init; }
    [Required(ErrorMessage ="ProductName is required")]
    public String productName { get; init; } = String.Empty;
    [Required(ErrorMessage ="Price is required")]
    public decimal price { get; init; }
    public int? CategoryId {get;init;}
    }
}
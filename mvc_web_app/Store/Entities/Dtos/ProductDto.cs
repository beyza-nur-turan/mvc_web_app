using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record ProductDto
    {
        //immutable olacakları için set yerine init yazıyoruz. bir kez tanımladıktan sonra değiştiremeyiz
        public int productId { get; init; }
        [Required(ErrorMessage = "ProductName is required")]
        public String productName { get; init; } = String.Empty;
        public String? Summary { get; init; } = String.Empty;
        public String? ImageUrl { get; set; } //bunu init yapmadım çünkü
        //ilk olarak dosya yüklemesi yapılıyor sonrasında url bilgisi girileceği için set edilmesi lazım
        //değiştirilemez olur ise bunu yapamayız
        [Required(ErrorMessage = "Price is required")]
        public decimal price { get; init; }
        public int? CategoryId { get; init; }
    }
}
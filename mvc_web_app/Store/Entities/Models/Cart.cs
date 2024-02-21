namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }
        public virtual void AddItem(Product product, int quantity)

        {
            //lines listesi üzerinde ilgili ürün var mı? kontrolü 
            CartLine? line = Lines.Where(l => l.Product.productId.Equals(product.productId)).FirstOrDefault();
            if (line is null) //eğer sepette o ürün yoksa ekleme yapar
            {
                Lines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else //eğer o ürün mevcutsa miktarını artırır
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product) =>
        Lines.RemoveAll(l => l.Product.productId.Equals(product.productId));
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.Product.price * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
}
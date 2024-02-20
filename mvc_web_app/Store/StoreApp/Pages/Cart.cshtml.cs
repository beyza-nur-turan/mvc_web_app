using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;

namespace StoreApp.Pages
{
    public class CartModel:PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart {get;set;} //IoC
        public string ReturnUrl { get; set; }="/";

 
        public CartModel(IServiceManager manager,Cart cart)
        {
            _manager = manager;
             Cart = cart;
        }

        
        //hangi sayfadan gelindiği bilgisini belirlemek için aşağıdaki kod kullanılır.
        //bunun nedeni kullanıcımın sepete gelmeden önce hangi sayfadan geldiğini öğrenerek onu o sayfaya tekrar yönlendirebileyim
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl=returnUrl ?? "/";
             //önceden geldiği bir sayfa var ise oraya yok ise ana sayfaya yönlendirme yapıldı
        }
        public IActionResult OnPost(int productId,string returnUrl)
        {
            Product? product=_manager.ProductService
            .GetOneProduct(productId,false);
            if(product is not null)
            {
                Cart.AddItem(product,1);
            }
            return Page();
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.productId.Equals(id)).Product);
            return Page();
        }
    }
}
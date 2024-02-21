using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using StoreApp.Infrastructure.Extensions;

namespace StoreApp.Pages
{
    public class CartModel:PageModel
    {
        private readonly IServiceManager _manager;
        public Cart Cart {get;set;} //IoC
        public string ReturnUrl { get; set; }="/";

 
        public CartModel(IServiceManager manager, Cart cartService)
        {
            _manager = manager;
            Cart=cartService;
        }

        
        //hangi sayfadan gelindiği bilgisini belirlemek için aşağıdaki kod kullanılır.
        //bunun nedeni kullanıcımın sepete gelmeden önce hangi sayfadan geldiğini öğrenerek onu o sayfaya tekrar yönlendirebileyim
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl=returnUrl ?? "/";
            //Cart=HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
             //önceden geldiği bir sayfa var ise oraya yok ise ana sayfaya yönlendirme yapıldı
        }
        public IActionResult OnPost(int productId,string returnUrl)
        {
            Product? product=_manager.ProductService
            .GetOneProduct(productId,false);
            if(product is not null)
            {
                //Cart=HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product,1);
                //HttpContext.Session.SetJson<Cart>("cart",Cart);
            }
            return RedirectToPage(new {returnUrl=returnUrl});
        }
        public IActionResult OnPostRemove(int id,string returnUrl)
        {
            //Cart=HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.productId.Equals(id)).Product);
           // HttpContext.Session.SetJson<Cart>("cart",Cart);
            return Page();
        }
    }
}
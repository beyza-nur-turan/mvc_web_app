using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApp.Models;

namespace StoreApp.Controllers
 {
    public class ProductController:Controller
    {
        private readonly RepositoryContext _context;

        //dependency injection patterni kullanılarak bilgi alma kullanma
        public ProductController(RepositoryContext context)
        { //oluşturulan repositorycontext örneği _context değişkenine atanıyor. böylece oaradaki verileri alabiliyoruz.
            _context = context;
        }

        public IActionResult Index() //tüm ürünleri listeler
        {
            
            var model = _context.Products.ToList();
            return View(model);
        }
        public IActionResult Get(int id) //id ye göre ürün getirir
        {
            Product product=_context.Products.First(p=>p.productId.Equals(id));//dbdeki id ile eşleşen ilk değeri ver
            return View(product);
        }

    }
 }
using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities.Models;
using Repositories.Contracts;
using Services.Contracts;

namespace StoreApp.Controllers
 {
    public class ProductController:Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        //dependency injection patterni kullanılarak bilgi alma kullanma


        public IActionResult Index() //tüm ürünleri listeler
        {
            
            var model = _manager.ProductService.GetAllProducts(false).ToList();
            return View(model);
        }
        public IActionResult Get([FromRoute(Name ="id")]int id) //id ye göre ürün getirir
        {
            var model= _manager.ProductService.GetOneProduct(id,false);
            return View(model);
        }

    }
 }
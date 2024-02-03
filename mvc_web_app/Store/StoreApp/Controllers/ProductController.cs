using System.Data.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Entities.Models;
using Repositories.Contracts;

namespace StoreApp.Controllers
 {
    public class ProductController:Controller
    {
        private readonly IRepositoryManager _manager;

        //dependency injection patterni kullanılarak bilgi alma kullanma
        public ProductController(IRepositoryManager manager)
        { 
            _manager = manager;
        }

        public IActionResult Index() //tüm ürünleri listeler
        {
            
            var model = _manager.Product.GetAllProducts(false).ToList();
            return View(model);
        }
        public IActionResult Get(int id) //id ye göre ürün getirir
        {
            var model= _manager.Product.GetOneProduct(id,false);
            return View(model);
        }

    }
 }
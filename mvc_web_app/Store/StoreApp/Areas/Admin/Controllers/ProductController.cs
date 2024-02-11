using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace StoreApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _manager;

        public ProductController(IServiceManager manager)
        {
            _manager = manager;
        }

        public IActionResult Index()
        {
            var model = _manager.ProductService.GetAllProducts(false);
            return View(model);
        }
        private SelectList GetCategoriesSelectList()
        {
            return ViewBag.Categories = new SelectList(_manager.CategoryService.GetAllCategories(false), "CategoryId", "CategoryName", "1");
        }
        public IActionResult Create()
        {
            //SelectList seçili listeyi defaultu 1 olacak şekilde yeni liste oluşturur.
            //view kısmında asp-items tag-helper ile bu kullanılacak
            ViewBag.Categories = GetCategoriesSelectList();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] ProductDtoForInsertion productDto, IFormFile file)//ıformfile ı dosya yüklemesi için tanımladık
        {
            if (ModelState.IsValid)
            {
                //file operations
                string path=Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot","images",file.FileName);

                using (var stream=new FileStream(path,FileMode.Create)) //dosya oluşturuyor.zaten varsa üstüne yazar
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl=String.Concat("/images/",file.FileName);//burda set ediyoruz. yukarda belli bir yol tanımladık 
                //ama bu productdb de images/filename olarak tanımlı bu nedenle birleştirip set ettik
                _manager.ProductService.CreateProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategoriesSelectList();
            var model = _manager.ProductService.GetOneProductForUpdate(id, false);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Update([FromForm] ProductDtoForUpdate productDto,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //file operations
                string path=Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot","images",file.FileName);

                using (var stream=new FileStream(path,FileMode.Create)) //dosya oluşturuyor.zaten varsa üstüne yazar
                {
                    await file.CopyToAsync(stream);
                }
                productDto.ImageUrl=String.Concat("/images/",file.FileName);//burda set ediyoruz. yukarda belli bir yol tanımladık 
                _manager.ProductService.UpdateOneProduct(productDto);
                return RedirectToAction("Index");
            }
            return View();

        }
        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _manager.ProductService.DeleteOneProduct(id);
            return RedirectToAction("Index");
        }
    }
}
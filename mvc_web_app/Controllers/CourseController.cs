using Microsoft.AspNetCore.Mvc;
using MVC_WEB_APP.Models;

namespace MVC_WEB_APP.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            var model =Repository.Applications;
            return View(model);
        }
        public IActionResult Apply()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]//sahtecilik vb bir durumda koruma sağlayan bir özelliktir
        public IActionResult Apply([FromForm] Candidate model) //fromform ile formdan veri geldiğini söyledik. bu şekilde daha sağlıklı 

        {
            if(Repository.Applications.Any(c=>c.Email.Equals(model.Email)))//modeldeki email ile girilen e mail aynı mı sorgusu
            {
                ModelState.AddModelError("","There is already an application for you");
            }
            if(ModelState.IsValid)
            {
                Repository.Add(model);//formdan gelen bilgileri repository modelinde saklıycak
            return View("Feedback",model);
            }
            return View();
            
        }
    }
}
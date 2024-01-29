using Microsoft.AspNetCore.Mvc;

namespace MVC_WEB_APP.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Apply()
        {
            return View();
        }
    }
}
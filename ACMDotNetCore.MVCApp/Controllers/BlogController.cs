using Microsoft.AspNetCore.Mvc;

namespace ACMDotNetCore.MVCApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

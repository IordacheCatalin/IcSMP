using Microsoft.AspNetCore.Mvc;

namespace IcSMP.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

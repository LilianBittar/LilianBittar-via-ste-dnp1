using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class AdultsController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
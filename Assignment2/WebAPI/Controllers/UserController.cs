using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UserController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}
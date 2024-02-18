using Microsoft.AspNetCore.Mvc;

namespace MasterDetails_Repo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

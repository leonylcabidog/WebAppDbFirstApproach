using Microsoft.AspNetCore.Mvc;

namespace WebAppDbFirstApproach.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

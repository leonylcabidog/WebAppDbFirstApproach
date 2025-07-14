using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDbFirstApproach.Data;
using WebAppDbFirstApproach.Models;

namespace WebAppDbFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly WebAppDbFirstApproachContext _dbcontext;

        public HomeController(ILogger<HomeController> logger, WebAppDbFirstApproachContext dbcontext)
        {
            _logger = logger;
            _dbcontext = dbcontext;
        }


        public IActionResult Index()
        {
            //List<Product> products = _dbcontext.tblproduct.Include(i => i.Images).ToList();
            List<Product> products = _dbcontext.tblproduct.Where(p => p.IsNew).Include(i => i.Images).ToList();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

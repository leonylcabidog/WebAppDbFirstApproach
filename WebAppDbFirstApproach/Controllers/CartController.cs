using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppDbFirstApproach.Data;

namespace WebAppDbFirstApproach.Controllers
{
    public class CartController : Controller
    {
        private readonly WebAppDbFirstApproachContext _dbcontext;

        public CartController(WebAppDbFirstApproachContext context)
        {
            _dbcontext = context;
        }
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<ShoppingCart>("cart") ?? new ShoppingCart();
            return View(cart);
        }


        public IActionResult AddToCart(int id)
        {
            var product = _dbcontext.tblproduct.Find(id);
            var cart = HttpContext.Session.GetObject<ShoppingCart>("cart") ?? new ShoppingCart();
            cart.AddToCart(product, 1);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var cart = HttpContext.Session.GetObject<ShoppingCart>("cart") ?? new ShoppingCart();
            cart.RemoveFromCart(id);
            HttpContext.Session.SetObject("cart", cart);
            return RedirectToAction("Index");
        }
    }
}

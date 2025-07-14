using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebAppDbFirstApproach.Data;
using WebAppDbFirstApproach.Models;

namespace WebAppDbFirstApproach.Controllers
{
    public class ProductController : Controller
    {
        private readonly WebAppDbFirstApproachContext _dbcontext;
        public ProductController(WebAppDbFirstApproachContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IActionResult Index()
        {
            List<Product> products = _dbcontext.tblproduct.Include(i => i.Images).ToList();

            return View(products);
        }

        public IActionResult Details(int? id)
        {

            if (id == null || id == 0)
            {
                return NotFound();
            }


            Product? product = _dbcontext.tblproduct
                .Include(i => i.Images)
                .FirstOrDefault(x => x.ProductId == id);
            //.Find(id);

            CategoryProduct categoryProduct = new CategoryProduct();
            categoryProduct.Products = product;
            categoryProduct.Categories = _dbcontext.tblcategories.ToList();

            if (product == null)
            {
                return NotFound();
            }

            return View(categoryProduct);
        }

        public IActionResult List()
        {
            List<Product> products = _dbcontext.tblproduct.Include(i => i.Images).ToList();

            return View(products);
        }
        [HttpGet]
        public IActionResult ViewProduct(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            //Product? product = _dbcontext.tblproduct.Find(id);
            Product? product = _dbcontext.tblproduct
                .Include(i => i.Images)
                .FirstOrDefault(x => x.ProductId == id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpGet]
        public IActionResult AddImage(int id)
        {
            ViewData["ProductId"] = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddImage(ProductImg productImg)
        {
            if (productImg == null)
            {
                ModelState.AddModelError("ImgPath", "Image Path is Required");
            }

            if (ModelState.IsValid)
            {
                _dbcontext.tblproductimg.Add(productImg);
                _dbcontext.SaveChanges();
                return RedirectToAction("ViewProduct", "Product", new { id = productImg.ProductId });
            }

            return View(productImg);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (product == null)
            {
                ModelState.AddModelError("Product", "Product Name is Required");
            }
            product.CreatedDate = DateTime.Now;

            //if (ModelState.IsValid)
            //{

                _dbcontext.tblproduct.Add(product);
                _dbcontext.SaveChanges();
                return RedirectToAction("List");
            //}

            //return View(product);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? product = _dbcontext.tblproduct.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (product == null)
            {
                ModelState.AddModelError("Product", "Product Name is Required");
            }

            //if (ModelState.IsValid)
            //{
                //_context.tblcategory.Update(category);
                _dbcontext.tblproduct.Update(product);
                _dbcontext.SaveChanges();
                return RedirectToAction("List");
            //}

            //return View(product);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product? prod = _dbcontext.tblproduct.Find(id);

            if (prod == null)
            {
                return NotFound();
            }

            return View(prod);
        }
        [HttpPost]
        public IActionResult Delete(Product prod)
        {
            //_db.AppEntries.Remove(obj);
            //_db.SaveChanges();
            _dbcontext.tblproduct.Remove(prod);
            _dbcontext.SaveChanges();
            return RedirectToAction("List");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebAppDbFirstApproach.Data;
using WebAppDbFirstApproach.Models;

namespace WebAppDbFirstApproach.Controllers
{
    public class CategoryController : Controller
    {
        private readonly WebAppDbFirstApproachContext _context;
            //ApplicationDbContext _context;
        public CategoryController(WebAppDbFirstApproachContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.tblcategories.ToList();

            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                ModelState.AddModelError("Category", "Category Name is Required");
            }
            _context.tblcategories.Add(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    _context.tblcategories.Add(category);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(category);
        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _context.tblcategories.Find(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (category == null)
            {
                ModelState.AddModelError("Category", "Category Name is Required");
            }

            _context.tblcategories.Update(category);
            _context.SaveChanges();
            return RedirectToAction("Index");
            //if (ModelState.IsValid)
            //{
            //    //_context.tblcategory.Update(category);
            //    _context.tblcategories.Update(category);
            //    _context.SaveChanges();
            //    return RedirectToAction("Index");
            //}

            //return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? cat = _context.tblcategories.Find(id);

            if (cat == null)
            {
                return NotFound();
            }

            return View(cat);
        }

        [HttpPost]
        public IActionResult Delete(Category cat)
        {
            //_db.AppEntries.Remove(obj);
            //_db.SaveChanges();
            _context.tblcategories.Remove(cat);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

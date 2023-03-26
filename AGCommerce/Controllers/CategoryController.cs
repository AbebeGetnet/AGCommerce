using AGCommerce.Data.Data;
using AGCommerce.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace AGCommerce.UI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AGCommerceDbContext _db;
        public CategoryController(AGCommerceDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
             IEnumerable<Category> categories = _db.Categories;
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {           
            return View();
        }        
        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (category == null)
            {
                ModelState.AddModelError("CategoryName", "The name can't be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["success"] = "Department created successfully";
                return RedirectToAction("Index");
            }
            IEnumerable<Category> categories = _db.Categories.ToList();
            return View(categories);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = _db.Categories.FirstOrDefault(d => d.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {

            if (category.Name == category.Name.ToString())
            {
                ModelState.AddModelError("NameCannotBeSame", "The name can't be same");
            }
            if (ModelState.IsValid)
            { }
            _db.Categories.Update(category);
            _db.SaveChanges();
            TempData["success"] = "Department updated successfully";
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var category = _db.Categories.FirstOrDefault(d => d.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var category = _db.Categories.FirstOrDefault(d => d.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(category);
            _db.SaveChanges();
            TempData["success"] = "Department deleted successfully";
            return RedirectToAction("Index");
        }

    }
}

using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Security.Cryptography;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _db;
        public CategoryController(ApplicationDBContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {

            IEnumerable <Category> objectCategoryList = _db.Categories.ToList();
            return View(objectCategoryList);
        }


        // GET
        public IActionResult  Create()
        {
            return View();
        }


        // POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if(obj.DisplayOrder!= null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name" , "The Display Order Cant Be as Same as The Name");
            }
            if (ModelState.IsValid)
            {

                _db.Categories.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }





        // GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();
            // var categoryFormDb = _db.Categories.FirstOrDefault(el => el.Id == id);
            var categoryFormDb = _db.Categories.Find(id);
            if (categoryFormDb != null)
            {

                return View(categoryFormDb);

            }
            return NotFound();
        }


        // POST Method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.DisplayOrder != null && obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Display Order Cant Be as Same as The Name");
            }
            if (ModelState.IsValid)
            {
                var x = obj;
                _db.Categories.Update(obj);
                _db.SaveChanges();

                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index", "Category");
            }
            return View(obj);
        }





    // GET
    public IActionResult Delete(int? id)
    {
        if (id == null || id == 0) return NotFound();
        // var categoryFormDb = _db.Categories.FirstOrDefault(el => el.Id == id);
        var categoryFormDb = _db.Categories.Find(id);
        if (categoryFormDb != null)
        {

            return View(categoryFormDb);

        }
        return NotFound();
    }


    // POST Method
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteCategory(Category obj)
        {
  
        var cat = _db.Categories.Find(obj.Id);
        if (cat == null) {

            return NotFound();
        }
        _db.Categories.Remove(cat);
        _db.SaveChanges();

            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
    }
}




}

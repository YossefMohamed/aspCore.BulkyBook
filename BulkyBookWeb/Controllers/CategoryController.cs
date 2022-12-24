using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(Category Obj)
        {
            if(Obj.DisplayOrder!= null && Obj.Name == Obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name" , "The Display Order Cant Be as Same as The Name");
            }
            if (ModelState.IsValid)
            {
                Console.WriteLine(Obj);
                _db.Categories.Add(Obj);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(Obj);
        }
    }
}

#region Usings

using System.Linq;
using AdvECommDay8.Models;
using Microsoft.AspNetCore.Mvc;

#endregion

namespace AdvECommDay8.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly MyContext _db;

        public CategoriesController(MyContext db)
        {
            _db = db;
        }

        // GET: Categories
        public IActionResult Index()
        {
            return View(_db.Categories.ToList());
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        public IActionResult Create(Category category)
        {
            _db.Add(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Edit/5
        public IActionResult Edit(int id)
        {
            var category = _db.Categories.Find(id);

            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            _db.Update(category);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // GET: Categories/Delete/5
        public IActionResult Delete(int id)
        {
            var category = _db.Categories.Find(id);
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
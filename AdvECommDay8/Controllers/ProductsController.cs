#region Usings

using System.Linq;
using AdvECommDay8.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

#endregion

namespace AdvECommDay8.Controllers
{
    public class ProductsController : Controller
    {
        private readonly MyContext _db;

        public ProductsController(MyContext db)
        {
            _db = db;
        }

        #region Action Methods

        public IActionResult Index()
        {
            // get all products from db in form of a list
            var products = _db.Products
                .Include(i => i.Category)
                .ToList();

            // give the list of products to the view and return the view
            return View(products);
        }

        #region CREATE

        // GET: /products/create
        public IActionResult Create()
        {
            // get all product categories from db
            var categories = _db.Categories.ToList();

            // prepare the categories to be presented in a dropdown list in the view
            var selectList = new SelectList(categories, "Id", "Name");

            // store the prepared categories in ViewData
            ViewData["categories"] = selectList;

            // return the create view to the user
            return View();
        }

        // POST: /products/create
        [HttpPost]
        public IActionResult Create(Product product)
        {
            // add the product to db
            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        #region UPDATE

        // GET: /products/update/1
        public IActionResult Update(int id)
        {
            // get the product with the given Id from the database
            var product = _db.Products.Find(id);

            // get all product categories from db
            var categories = _db.Categories.ToList();

            // prepare the categories to be presented in a dropdown list with the default value equal to the product's current category
            var selectList = new SelectList(categories, "Id", "Name", product.Category.Id);

            // store the prepared categories in ViewData
            ViewData["categories"] = selectList;

            // return the product to the view
            return View(product);
        }

        // POST: /products/update/1
        [HttpPost]
        public IActionResult Update(Product product)
        {
            _db.Products.Update(product);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion

        // GET: /products/delete/1
        public IActionResult Delete(int id)
        {
            // get the product in db that matches the sent Id
            var product = _db.Products.Find(id);

            // remove the product from the db
            _db.Products.Remove(product);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
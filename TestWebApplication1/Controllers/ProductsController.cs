using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using TestWebApplication1.Data;
using TestWebApplication1.Models;

namespace TestWebApplication1.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _db;
        public ProductsController(ApplicationDbContext db)
        {
            _db = db ;
        }
        public MyProductsModel Product { get; set; }
        public IActionResult AllProducts()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult ClassicCars()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult Motorcycles()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult Planes()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult Ships()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult Trains()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult TrucksandBuses()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult VintageCars()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult Autoart_Studio_Design()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Carousel_DieCast_Legends()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Classic_Metal_Creations()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Exoto_Designs()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Gearbox_Collectibles()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Highway_66_Mini_Classics()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Min_Lin_Diecast()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Motor_City_Art_Classics()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Red_Start_Diecast()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Second_Gear_Diecast()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Studio_M_Art_Models()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Unimax_Art_Galleries()
        {
            var products = _db.Products;
            return View(products);
        }
        public IActionResult Welly_Diecast_Productions()
        {
            var products = _db.Products;
            return View(products);
        }

        public IActionResult Details(string id)
        {
            var product = _db.Products.FirstOrDefault(p=>p.productCode == id);
            if (product==null)
            {
                return NotFound();
            }
            return View(product);
        }
        public IActionResult AddNewModel()
        {
            Product = new MyProductsModel();
            return View(Product);
        }
        [HttpPost]
        public IActionResult AddNewModel(MyProductsModel model)
        {
            _db.Products.Add(model);
            _db.SaveChanges();
            return RedirectToAction("AllProducts");
        }

    }
}

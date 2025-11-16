using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using TestWebApplication1.Data;
using Microsoft.AspNetCore.Http;
using TestWebApplication1.Models;

namespace TestWebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly ApplicationDbContext _db;

        private List<BasketItem> _basketItems;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
            _basketItems = new List<BasketItem>();
        }
        public MyProductsModel ToBasketModel { get; set; }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AddToBasket(string? Id) 
        {
            var modelToAdd = _db.Products.Find(Id);
            var basketitems = HttpContext.Session.Get<List<BasketItem>>("Basket") ?? new List<BasketItem>();
            var exixtsingModelItem = basketitems.FirstOrDefault(item => item.Model.productCode == Id);
            if (exixtsingModelItem!=null)
            {
                exixtsingModelItem.Quantity++;
            }
            else
            {
                basketitems.Add(new BasketItem
                {
                    Model=modelToAdd,
                    Quantity=1
                });
            }

            HttpContext.Session.Set("Basket", basketitems);   
            return RedirectToAction("ViewCart");
        }
        [HttpGet]
        public IActionResult ViewCart()
        {
            var basketitems = HttpContext.Session.Get<List<BasketItem>>("Basket") ?? new List<BasketItem>();

            var basketViewModel = new BasketItemViewModel
            {
                BasketItems = basketitems,
                TotalPrice = (int)basketitems.Sum(item => item.Model.buyPrice * item.Quantity)
            };
            return View(basketViewModel);
        }

        public IActionResult DeleteFromBasket(string? Id)
        {
            var basketitems = HttpContext.Session.Get<List<BasketItem>>("Basket") ?? new List<BasketItem>();
            var modelToDelete = basketitems.FirstOrDefault(item=>item.Model.productCode==Id);
            if (modelToDelete.Quantity>1)
            {
                modelToDelete.Quantity--;
            }
            else
            {
                basketitems.Remove(modelToDelete);
            }
            HttpContext.Session.Set("Basket", basketitems);
            return RedirectToAction("ViewCart");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

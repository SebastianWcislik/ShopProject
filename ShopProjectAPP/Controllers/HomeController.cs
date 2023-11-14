using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ShopProjectAPP.Helpers;
using ShopProjectAPP.Models;
using System.Diagnostics;

namespace ShopProjectAPP.Controllers
{
    public class HomeController : Controller
    {
        HttpClient client;
        GetResponse responseHelper = new GetResponse();
        IMemoryCache cache;
        // dodanie klasy z obsługą koszyka zakupowego
        // cachowanie danych 

        public HomeController(IMemoryCache cache)
        {
            client = new HttpClient();
            this.cache = cache;
        }

        public async Task<IActionResult> Index()
        {
            //var result = await responseHelper.GetResponseAsync<List<string>>(client, "https://localhost:44332/Product/Test");
            //var resultCart = new List<string>();
            //cache.Set<List<string>>("cart1", resultCart);

            //var getCart = cache.Get<List<string>>("cart1");
            return View(new ErrorViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
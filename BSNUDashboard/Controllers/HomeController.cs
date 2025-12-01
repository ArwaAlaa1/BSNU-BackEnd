using BSNUDashboard.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BSNUDashboard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> Index()
        {
            var x = User.Identity.IsAuthenticated;
            //bool flag = false;
            //if (User.IsInRole("Admin"))
            //{
            //    var list = await _product.GetWaitingProducts();
            //    if (list.Any())
            //    {
            //        flag = true;
            //    }
            //    return View(flag);
            //}
            return RedirectToAction(nameof(Index),"News");
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

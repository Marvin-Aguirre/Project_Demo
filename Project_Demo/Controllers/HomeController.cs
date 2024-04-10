using Microsoft.AspNetCore.Mvc;
using Project_Demo.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

namespace Project_Demo.Controllers
{

    //[Authorize]

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles ="Administrador")]
        public IActionResult Ventas()
        {
            return View();
        }

        [Authorize(Roles = "Cliente, Administrador")]
        public IActionResult Compras()
        {
            return View();
        }

        [Authorize(Roles = "Supervisor, Administrador")]
        public IActionResult Clientes()
        {
            return View();
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

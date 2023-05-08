using document_viewer_app.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace document_viewer_app.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string nombreArchivo = "")
        {
            string urlCompleta = $"https://bconnectstoragetest.blob.core.windows.net/temp/{nombreArchivo}";
            var report = new TestReport(urlCompleta);

            return View(report); // Pasar el objeto TestReport creado como modelo de la vista
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
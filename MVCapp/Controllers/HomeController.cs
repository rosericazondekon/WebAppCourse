using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCapp.Models;

namespace MVCapp.Controllers;

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

    public IActionResult Privacy()
    {
        return View();
    }

    // public IActionResult Feedback()
    // {
    //     return View();
    // }

    [HttpPost]
    public IActionResult SubmitFeedback(string userName, string userFeedback)
    {
        // Process the feedback data (e.g., save to a database)
        // Simulate server processing delay for demonstration purposes
        System.Threading.Thread.Sleep(2000);
        return Json(new { success = true, message = "Feedback submitted successfully!" });
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

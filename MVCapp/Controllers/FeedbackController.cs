using Microsoft.AspNetCore.Mvc;
public class FeedbackController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitFeedback(string userName, string userFeedback)
    {
        // Process the feedback data (e.g., save to a database)
        // Simulate server processing delay for demonstration purposes
        System.Threading.Thread.Sleep(2000);
        return Json(new { success = true, message = "Feedback successfully submitted!" });
    }
}
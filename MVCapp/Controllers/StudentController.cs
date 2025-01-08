
using Microsoft.AspNetCore.Mvc;

namespace MVCapp.Controllers;
public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SubmitStudent(string name, string dob, decimal tuition)
    {
        // Process the student data (e.g., save to a database)
        // Simulate server processing delay for demonstration purposes
        System.Threading.Thread.Sleep(2000);
        return Json(new { success = true, message = "Student data successfully submitted!" });
    }
}
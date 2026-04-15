using Microsoft.AspNetCore.Mvc;

namespace NET104_Buoi2._2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

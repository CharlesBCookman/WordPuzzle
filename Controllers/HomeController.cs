using Microsoft.AspNetCore.Mvc;

namespace WordPuzzle.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}
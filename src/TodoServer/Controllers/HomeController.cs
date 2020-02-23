using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Controllers
{
  public class HomeController : Controller
  {
    public IActionResult Index()
      => File("index.html", "text/html");
  }
}

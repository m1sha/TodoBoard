using Microsoft.AspNetCore.Mvc;

namespace TodoServer.Controllers
{
  /// <summary>
  /// Entry point controller
  /// </summary>
  public class HomeController : Controller
  {
    /// <summary>
    /// Entry point in the web-app
    /// </summary>
    /// <returns></returns>
    public IActionResult Index()
      => File("index.html", "text/html");
  }
}

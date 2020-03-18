using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoServer.Models.Entities;
using TodoServer.Models.Services.Intf;

namespace TodoServer.Controllers
{
  public class UserController : ControllerBase
  {
    private readonly ILogger<UserController> logger;
    private readonly IUserService service;

    public UserController(ILogger<UserController> logger, IUserService service)
    {
      this.logger = logger;
      this.service = service;
    }

    /// <summary>
    /// Get list of users
    /// </summary>
    /// <param name="filter">Search filter</param>
    /// <returns></returns>
    [Route("User/List")]
    [HttpPost]
    public async Task<IActionResult> GetList([FromBody] UserFilter filter)
    {
      var result = await service.GetList(filter);
      return Ok(result);
    }
  }
}

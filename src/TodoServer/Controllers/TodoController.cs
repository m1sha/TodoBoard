using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoServer.Models.Entities;
using TodoServer.Models.Services.Intf;

namespace TodoServer.Controllers
{
  /// <summary>
  /// Todo controller
  /// </summary>
  public class TodoController: ControllerBase
  {
    private readonly ILogger<TodoController> logger;
    private readonly ITodoService service;

    public TodoController(ILogger<TodoController> logger, ITodoService service)
    {
      this.logger = logger;
      this.service = service;
    }

    /// <summary>
    /// Get list of ToDo items
    /// </summary>
    /// <param name="filter">Search filter</param>
    /// <returns></returns>
    [Route("Todo/List")]
    [HttpPost]
    public async Task<IActionResult> GetList([FromBody] TodoFilter filter)
    {
      var result = await service.GetList(filter);
      return Ok(result);
    }

    /// <summary>
    /// Add new or update exists ToDo item in the ToDo items list
    /// </summary>
    /// <param name="item">Todo item</param>
    /// <returns></returns>
    [Route("Todo/Add")]
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] TodoItem item)
    {
      var result = await service.AddOrUpdate(item);
      return Ok(result);
    }

    /// <summary>
    /// Remove ToDos by uids
    /// </summary>
    /// <param name="uids">Todo item</param>
    /// <returns></returns>
    [Route("Todo/Remove")]
    [HttpPost]
    public async Task<IActionResult> Remove([FromBody] string[] ids)
    {
      await service.Remove(ids);
      return Ok();
    }
  }
}

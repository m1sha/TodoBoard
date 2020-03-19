using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoServer.Models.Services.Intf;

namespace TodoServer.Hubs
{
  public class TodoCrudSyncHub: Hub
  {
    private ITodoService service;

    public TodoCrudSyncHub(ITodoService service)
    {
      this.service = service;
    }

    public async Task TodoListSending(TodoFilter filter)
    {
      var items = await service.GetList(filter);
      await Clients.Others.SendAsync("TodoListReceived", new { filter, items });
    }
  }
}

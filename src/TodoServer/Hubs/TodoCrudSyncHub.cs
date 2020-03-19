using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Hubs
{
  public class TodoCrudSyncHub: Hub
  {
    public async Task TodoListSending(int num)
    {
      await Clients.Others.SendAsync("TodoListReceived", num);
    }
  }
}

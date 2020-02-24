using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Services.Intf;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Services
{
  public class TodoService : ITodoService
  {
    private readonly IStorage storage;

    public TodoService(IStorage storage)
    {
      this.storage = storage;
    }

    public Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
      => storage.Todo.GetList(filter);

    public Task<TodoItem> GetOne(string uid)
    {
      throw new NotImplementedException();
    }

    public async Task<string> AddOrUpdate(TodoItem item)
    {
      var users = await storage.User.GetList(new UserFilter());
      item.Status = TodoStatus.New;
      item.UserAssign = users.First();
      item.UserCreator = users.First();

      return await storage.Todo.AddOrUpdate(item);
    }
       

    public Task Remove(string[] uids)
      => storage.Todo.Remove(uids);
  }
}

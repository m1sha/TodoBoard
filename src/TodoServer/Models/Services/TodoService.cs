using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using TodoServer.Models.Entities.Validation;
using TodoServer.Models.Services.Intf;


namespace TodoServer.Models.Services
{
  public class TodoService : ITodoService
  {
    private readonly ITodoBoardStorage storage;

    public TodoService(ITodoBoardStorage storage)
    {
      this.storage = storage;
    }

    public Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
      => storage.Todos.GetList(filter);

    public Task<TodoItem> GetOne(string uid)
    {
      throw new NotImplementedException();
    }

    public async Task<string> AddOrUpdate(TodoItem item)
    {
      item.Validate();
      return await storage.Todos.AddOrUpdate(item);
    }
       

    public Task Remove(string[] uids)
      => storage.Todos.Remove(uids);
  }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Entities.Validation;
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
      item.Validate();
      return await storage.Todo.AddOrUpdate(item);
    }
       

    public Task Remove(string[] uids)
      => storage.Todo.Remove(uids);
  }
}

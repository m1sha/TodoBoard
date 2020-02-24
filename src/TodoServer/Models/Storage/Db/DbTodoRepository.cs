using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Storage.Db
{
  public class DbTodoRepository : DbRepositoryBase, ITodoRepository
  {
    public DbTodoRepository(string connectionString) 
      : base(connectionString)
    {
    }

    public Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
    {
      throw new NotImplementedException();
    }

    public Task<string> AddOrUpdate(TodoItem item)
    {
      throw new NotImplementedException();
    }
    
  }
}

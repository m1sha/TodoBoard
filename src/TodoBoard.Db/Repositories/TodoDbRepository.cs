using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using PagedList.Core;

namespace TodoBoard.Db.Repositories
{
  public class TodoDbRepository :  ITodoRepository
  {
    private readonly Func<TodoBoardDbContext> dbContextFactory;

    public TodoDbRepository(Func<TodoBoardDbContext> dbContextFactory) 
    {
      this.dbContextFactory = dbContextFactory;
    }

    async public Task<string> AddOrUpdate(TodoItem item)
    {
      using var context = dbContextFactory.Invoke();

      item.AssignToUser = await context.FindAsync<User>(item.AssignToUser.Id);
      item.CreateByUser = await context.FindAsync<User>(item.CreateByUser.Id);
      
      if (context.Todos.AsNoTracking().Any(p => p.Id == item.Id))
      {
        context.Todos.Update(item);
      }
      else
      {
        await context.Todos.AddAsync(item);
      }
      
      await context.SaveChangesAsync();
      return item.Id.ToString();
    }

    public Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
       => Task.Run(() =>
       {
         using var context = dbContextFactory.Invoke();
         return context.Todos

           .OrderByDescending(p=>p.ChangeDate)
           .Include(p => p.AssignToUser)
           .Include(p => p.CreateByUser)
           .AsNoTracking()
           .ToPagedList(filter.Page, filter.PageCount)
           .AsEnumerable();
       });

    async public Task Remove(string[] uids)
    {
      using var context = dbContextFactory.Invoke();
      foreach (var uid in uids)
      {
        var id = new Guid(uid);
        var item = context.ChangeTracker
          .Entries<TodoItem>()
          .FirstOrDefault(p=>p.Entity.Id == id)?.Entity 
          ?? new TodoItem { Id = id };

        context.Todos.Remove(item);
      }
      await context.SaveChangesAsync();
    }
  }
}

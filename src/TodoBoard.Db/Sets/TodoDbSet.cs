using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using PagedList;
using PagedList.Core;

namespace TodoBoard.Db.Sets
{
  public class TodoDbSet : DbSetWrapper<TodoItem>, ITodoRepository
  {
    public TodoDbSet(DbContext context, DbSet<TodoItem> dbSet) : base(context, dbSet)
    {
    }

    async public Task<string> AddOrUpdate(TodoItem item)
    {
      item.AssignToUser = await Context.FindAsync<User>(item.AssignToUser.Id);
      item.CreateByUser = await Context.FindAsync<User>(item.CreateByUser.Id);
      await AddAsync(item);
      await Context.SaveChangesAsync();
      return item.Id.ToString();
    }

    public Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
       => Task.Run(() =>
       {
         return DbSet
           .AsNoTracking()
           .OrderByDescending(p=>p.ChangeDate)
           .Include(p => p.AssignToUser)
           .Include(p => p.CreateByUser)
           .ToPagedList(filter.Page, filter.PageCount)
           .AsEnumerable();
       });

    async public Task Remove(string[] uids)
    {
      RemoveRange(uids.Select(p => new TodoItem() { Id = Guid.Parse(p) }));
      await Context.SaveChangesAsync();
    }
  }
}

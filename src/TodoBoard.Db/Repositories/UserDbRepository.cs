using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;

namespace TodoBoard.Db.Repositories
{
  public class UserDbRepository : IUserRepository
  {
    private readonly Func<TodoBoardDbContext> dbContextFactory;

    public UserDbRepository(Func<TodoBoardDbContext> dbContextFactory)
    {
      this.dbContextFactory = dbContextFactory;
    }

    async public Task<string> AddUser(User user)
    {
      using var context = dbContextFactory.Invoke();
      await context.AddAsync(user);
      await context.SaveChangesAsync();
      return user.Id.ToString();
    }

    public Task<IEnumerable<User>> GetList(UserFilter filter)
       => Task.Run(() =>
          {
            using var context = dbContextFactory.Invoke();
            return context.Users
              .AsNoTracking()
              .OrderByDescending(p => p.Name)
              .ToPagedList(filter.Page, filter.PageCount)
              .AsEnumerable();
          });
  }
}

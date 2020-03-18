using Microsoft.EntityFrameworkCore;
using PagedList.Core;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;

namespace TodoBoard.Db.Sets
{
  public class UserDbSet : DbSetWrapper<User>, IUserRepository
  {
    public UserDbSet(DbContext context, DbSet<User> dbSet) : base(context, dbSet)
    {
    }

    public Task<IEnumerable<User>> GetList(UserFilter filter)
       => Task.Run(() =>
          {
            return DbSet
              .AsNoTracking()
              .OrderByDescending(p => p.Name)
              .ToPagedList(filter.Page, filter.PageCount)
              .AsEnumerable();
          });
  }
}

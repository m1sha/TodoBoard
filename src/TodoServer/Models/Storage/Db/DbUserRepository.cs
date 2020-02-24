using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Storage.Db
{
  public class DbUserRepository : DbRepositoryBase, IUserRepository
  {
    public DbUserRepository(string connectionString) : base(connectionString)
    {
    }
  }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;

namespace TodoServer.Models.Storage.Intf
{
  public interface IUserRepository
  {
    /// <summary>
    /// Get list of users
    /// </summary>
    /// <param name="filter">Search filter</param>
    /// <returns></returns>
    public Task<IEnumerable<User>> GetList(UserFilter filter);
  }
}

using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;

namespace TodoServer.Models.Services.Intf
{
  public interface IUserService
  {
    /// <summary>
    /// Get list of users
    /// </summary>
    /// <param name="filter">Search filter</param>
    /// <returns></returns>
    public Task<IEnumerable<User>> GetList(UserFilter filter);
  }
}

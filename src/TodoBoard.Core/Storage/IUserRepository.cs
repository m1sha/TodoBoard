using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;

namespace TodoBoard.Core.Storage
{
  public interface IUserRepository
  {
    /// <summary>
    /// Get list of users
    /// </summary>
    /// <param name="filter">Search filter</param>
    /// <returns></returns>
    public Task<IEnumerable<User>> GetList(UserFilter filter);

    /// <summary>
    /// Add user
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public Task<string> AddUser(User user);
  }
}

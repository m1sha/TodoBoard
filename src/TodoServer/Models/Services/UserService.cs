using System.Collections.Generic;
using System.Threading.Tasks;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using TodoServer.Models.Services.Intf;


namespace TodoServer.Models.Services
{
  public class UserService: IUserService
  {
    private readonly ITodoBoardStorage storage;

    public UserService(ITodoBoardStorage storage)
    {
      this.storage = storage;
    }

    public Task<IEnumerable<User>> GetList(UserFilter filter)
      => storage.Users.GetList(filter);
  }
}

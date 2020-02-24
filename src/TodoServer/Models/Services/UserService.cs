using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Services.Intf;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Services
{
  public class UserService: IUserService
  {
    private readonly IStorage storage;

    public UserService(IStorage storage)
    {
      this.storage = storage;
    }

    public Task<IEnumerable<User>> GetList(UserFilter filter)
      => storage.User.GetList(filter);
  }
}

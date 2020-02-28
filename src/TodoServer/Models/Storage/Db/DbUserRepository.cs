using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Storage.Db
{
  public class DbUserRepository : DbRepositoryBase, IUserRepository
  {
    public DbUserRepository(string connectionString) : base(connectionString)
    {
    }

    public async Task<IEnumerable<User>> GetList(UserFilter filter)
    => await Task.Run(() =>
    {
      using var connection = CreateConnection();
      connection.Open();
      using var sp = CreateSpCommand(connection, "gsp_user_select");
      using var reader = sp.ExecuteReader();
      var result = new List<User>();
      while (reader.Read())
      {
        #region user fill

        var i = 0;
        var item = new User()
        {
          Uid = reader.GetString(i++),
          Name = reader.GetString(i++),
        };
        #endregion

        result.Add(item);
      }
      return result;
    });
  }
}

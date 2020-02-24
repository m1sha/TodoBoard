using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Storage.Db
{
  public class DbTodoRepository : DbRepositoryBase, ITodoRepository
  {
    public DbTodoRepository(string connectionString)
      : base(connectionString)
    {
    }

    public async Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
      => await Task.Run(() =>
      {
        using var connection = GetConnection();
        using var sp = CreateSpCommand(connection, "gsp_todo_select");
        using var reader = sp.ExecuteReader();
        var result = new List<TodoItem>();
        while (reader.Read())
        {
          #region todo fill

          var i = 0;
          var item = new TodoItem()
          {
            Uid = reader.GetString(i++),
            Title = reader.GetString(i++),
            Message = reader.GetString(i++),
            CreateDate = reader.GetDateTime(i++),
            ChangeDate = reader.GetDateTime(i++),
            Status = (TodoStatus)reader.GetInt32(i++),
            UserCreator = new User()
            {
              Uid = reader.GetString(i++),
              Name = reader.GetString(i++),
            },
            UserAssign = new User()
            {
              Uid = reader.GetString(i++),
              Name = reader.GetString(i++),
            }
          };
          #endregion

          result.Add(item);
        }
        return result;
      });

    public async Task<string> AddOrUpdate(TodoItem item)
      => await Task.Run(() =>
      {
        using var connection = GetConnection();
        using var sp = CreateSpCommand(connection, "gsp_todo_insert");
        var uid = item.Uid;
        if (string.IsNullOrEmpty(uid))
          uid = Guid.NewGuid().ToString("N");

        AddParameter(sp, "@vcUid", DbType.String, uid, 32);
        AddParameter(sp, "@nvTitle", DbType.String, item.Title, 160);
        AddParameter(sp, "@nvText", DbType.String, item.Message, 1000);
        AddParameter(sp, "@iStatus", DbType.Int32, item.Status);
        AddParameter(sp, "@vcUserCreatorUid", DbType.String, item.UserCreator.Uid, 32);
        AddParameter(sp, "@vcUserAssignUid", DbType.String, item.UserAssign.Uid, 32);

        sp.ExecuteNonQuery();
        return uid;
      });

    public async Task Remove(string[] uids)
       => await Task.Run(() =>
       {
         using var connection = GetConnection();
         Parallel.ForEach(uids, uid =>
         {
           using var sp = CreateSpCommand(connection, "gsp_todo_delete");
           AddParameter(sp, "@vcUid", DbType.String, uid, 32);
           sp.ExecuteNonQuery();
         });
       });
  }
}

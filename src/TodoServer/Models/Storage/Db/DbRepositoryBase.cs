using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace TodoServer.Models.Storage.Db
{
  public abstract class DbRepositoryBase
  {
    protected DbRepositoryBase(string connectionString)
    {
      ConnectionString = connectionString;
    }

    protected string ConnectionString { get; }


    protected DbConnection GetConnection()
    {
      var result = new SqlConnection(ConnectionString);
      result.Open();
      return result;
    }

    protected DbCommand CreateSpCommand(DbConnection connection, string spName)
    {
      var result = connection.CreateCommand();
      result.CommandType = CommandType.StoredProcedure;
      result.CommandText = spName;
      
      return result;
    }

    protected void AddParameter(DbCommand command, string parameterName, DbType type, object value, int size = 0)
    {
      var parameter = command.CreateParameter();
      parameter.ParameterName = parameterName;
      parameter.DbType = type;
      parameter.Value = value;
      parameter.Size = size;
      command.Parameters.Add(parameter);
    }
  }
}

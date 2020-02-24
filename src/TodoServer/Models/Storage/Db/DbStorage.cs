using System;
using System.Data.SqlClient;
using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Storage.Db
{
  public class DbStorage : IStorage
  {
    private readonly TodoStorageSettings settings;
    private readonly Lazy<DbTodoRepository> todoRepositoryLazy;
    private readonly Lazy<DbUserRepository> userRepositoryLazy;

    public DbStorage(TodoStorageSettings settings)
    {
      this.settings = settings;
      todoRepositoryLazy = new Lazy<DbTodoRepository>(() => new DbTodoRepository(GetFullConnectionString(settings)));
      userRepositoryLazy = new Lazy<DbUserRepository>(() => new DbUserRepository(GetFullConnectionString(settings)));
    }

    public ITodoRepository Todo => todoRepositoryLazy.Value;

    public IUserRepository User => userRepositoryLazy.Value;

    public void CheckConnection()
    {
      using var connection = new SqlConnection(settings.ConnectionString);
      try
      {
        connection.Open();
      }
      catch (SqlException e)
      {
        throw new Exception($"Cannot to connect to SQL Server. Please check your connection string {settings.ConnectionString}.", e);
      }
    }

    public void CreateIfNotExists()
    {
      DbInstaller.Install(settings);
    }

    public static string GetFullConnectionString(TodoStorageSettings settings)
      => $"Database={settings.DbName};{settings.ConnectionString}";
  }
}

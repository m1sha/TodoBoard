using System;
using System.Data.SqlClient;
using TodoServer.Models.Storage.Db;

namespace TodoServer.Models.Storage
{
  public class DbStorage : IStorage
  {
    private readonly TodoStorageSettings settings;

    public DbStorage(TodoStorageSettings settings)
    {
      this.settings = settings;
    }

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
      DbInstaller.Install();
    }
  }
}

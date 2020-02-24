namespace TodoServer.Models.Storage.Db
{
  public abstract class DbRepositoryBase
  {
    protected DbRepositoryBase(string connectionString)
    {
      ConnectionString = connectionString;
    }

    protected string ConnectionString { get; }

  }
}

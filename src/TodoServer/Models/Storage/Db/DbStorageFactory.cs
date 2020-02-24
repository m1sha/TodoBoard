using TodoServer.Models.Storage.Intf;

namespace TodoServer.Models.Storage.Db
{
  public static class DbStorageFactory
  {
    public static IStorage Create(TodoStorageSettings settings)
      => new DbStorage(settings);
  }
}

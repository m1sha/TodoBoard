namespace TodoServer.Models.Storage
{
  public static class DbStorageFactory
  {
    public static IStorage Create(TodoStorageSettings settings)
      => new DbStorage(settings);
  }
}

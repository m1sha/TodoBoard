namespace TodoServer.Models.Storage
{
  public class TodoStorageSettings
  {
    public string ConnectionString { get; set; }
    public string DbName { get; set; }

    public string SqlInstallFileName { get; set; }
  }
}

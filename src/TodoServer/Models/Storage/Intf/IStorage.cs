namespace TodoServer.Models.Storage.Intf
{

  /// <summary>
  /// Abstract storage for Todo Board
  /// </summary>
  public interface IStorage
  {
    /// <summary>
    /// Check connection to a storage
    /// </summary>
    void CheckConnection();

    /// <summary>
    /// Create a storage if a storage isn't exists
    /// </summary>
    void CreateIfNotExists();

    /// <summary>
    /// Todo operations repository
    /// </summary>
    ITodoRepository Todo { get; }

    /// <summary>
    /// User operations repository
    /// </summary>
    IUserRepository User { get; }
  }
}

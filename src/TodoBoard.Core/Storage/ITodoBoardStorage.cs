using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBoard.Core.Storage
{
  /// <summary>
  /// Abstract storage for Todo Board
  /// </summary>
  public interface ITodoBoardStorage
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
    ITodoRepository Todos { get; }

    /// <summary>
    /// User operations repository
    /// </summary>
    IUserRepository Users { get; }
  }
}

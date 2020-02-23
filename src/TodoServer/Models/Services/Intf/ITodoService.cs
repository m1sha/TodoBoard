using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;

namespace TodoServer.Models.Services.Intf
{
  /// <summary>
  /// Interface of Todo Service
  /// </summary>
  public interface ITodoService
  {
    /// <summary>
    /// Get list of ToDo items
    /// </summary>
    /// <param name="filter">Search filter</param>
    /// <returns></returns>
    public Task<IEnumerable<TodoItem>> GetList(TodoFilter filter);

    /// <summary>
    /// Get ToDo item by UID
    /// </summary>
    /// <param name="uid">Uniq identifier</param>
    /// <returns></returns>
    public Task<TodoItem> GetOne(string uid);

    /// <summary>
    /// Add new or update exists ToDo item in the ToDo items list
    /// </summary>
    /// <param name="item">Todo item</param>
    /// <returns></returns>
    public Task<string> AddOrUpdate(TodoItem item);

    /// <summary>
    /// Remove ToDo items from the ToDo items list by item identifiers
    /// </summary>
    /// <param name="uids">Uniq identifiers</param>
    /// <returns></returns>
    public Task Remove(string[] uids);
  }
}

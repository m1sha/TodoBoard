using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoServer.Models.Entities;
using TodoServer.Models.Services.Intf;
using TodoServer.Models.Storage;

namespace TodoServer.Models.Services
{
  public class TodoService : ITodoService
  {

    public TodoService(IStorage storage)
    {

    }

    static readonly List<TodoItem> todos = new List<TodoItem>() {
      new TodoItem() {Title = "Task 1", Message="Message of task 1", CreateDate = DateTime.Now, Uid = "1"},
      new TodoItem() {Title = "Task 2", Message="Message of task 2", CreateDate = DateTime.Now, Uid = "2"},
      new TodoItem() {Title = "Task 3", Message="Message of task 3", CreateDate = DateTime.Now, Uid = "3"},
      new TodoItem() {Title = "Task 4", Message="Message of task 4", CreateDate = DateTime.Now, Uid = "4"},
      new TodoItem() {Title = "Task 5", Message="Message of task 5", CreateDate = DateTime.Now, Uid = "5"},
      new TodoItem() {Title = "Task 6", Message="Message of task 6", CreateDate = DateTime.Now, Uid = "6"},
      new TodoItem() {Title = "Task 7", Message="Message of task 7", CreateDate = DateTime.Now, Uid = "7"},
      new TodoItem() {Title = "Task 8", Message="Message of task 8", CreateDate = DateTime.Now, Uid = "8"},
      new TodoItem() {Title = "Task 9", Message="Message of task 9", CreateDate = DateTime.Now, Uid = "9"},
      new TodoItem() {Title = "Task 10", Message="Message of task 10", CreateDate = DateTime.Now, Uid = "10"}
    };


    public async Task<IEnumerable<TodoItem>> GetList(TodoFilter filter)
      => await Task.Run(() =>
      {
        return todos;
      });

    public Task<TodoItem> GetOne(string uid)
    {
      throw new NotImplementedException();
    }

    public async Task<string> AddOrUpdate(TodoItem item)
       => await Task.Run(() =>
       {
         todos.Add(item);
         return item.Uid;
       });
    

    public Task Remove(string[] uids)
    {
      throw new NotImplementedException();
    }
  }
}

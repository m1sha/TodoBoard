using System;

namespace TodoServer.Models.Entities
{
  public class TodoItem
  {
    public string Uid { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public TodoStatus Status { get; set; }

    public TodoType Type { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ChangeDate { get; set; }

    public User UserCreator { get; set; }

    public User UserAssign { get; set; }
  }
}

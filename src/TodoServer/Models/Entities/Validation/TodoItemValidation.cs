using System;

namespace TodoServer.Models.Entities.Validation
{
  public static class TodoItemValidation
  {
    public static void Validate(this TodoItem item)
    {
      if (item == null) throw new Exception("TodoItem is null.");
      if (string.IsNullOrEmpty(item.Title)) throw new Exception("TodoItem Title is empty.");
      if (item.Status == TodoStatus.Unknown) throw new Exception("TodoItem Status is unknown.");
      if (item.Type == TodoType.Unknown) throw new Exception("TodoItem Type is unknown.");
      if (string.IsNullOrEmpty(item.UserAssign?.Uid)) throw new Exception("TodoItem UserAssign Uid is empty.");
      if (string.IsNullOrEmpty(item.UserCreator?.Uid)) throw new Exception("TodoItem UserCreator Uid is empty.");
    }
  }
}

using System;

namespace TodoBoard.Core.Entities
{
  public class TodoItem
  {
    public Guid Id { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public TodoStatus Status { get; set; }

    public DateTime CreateDate { get; set; }

    public DateTime ChangeDate { get; set; }

    //public Guid CreateByUserId { get; set; }

    public User CreateByUser { get; set; }

    //public Guid AssignToUserId { get; set; }

    public User AssignToUser { get; set; }
  }

  public enum TodoStatus : int
  {
    Unknown = 0,
    New = 1,
    InWork = 2,
    Finished = 3
  }
}

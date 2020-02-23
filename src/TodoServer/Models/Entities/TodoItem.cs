using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoServer.Models.Entities
{
  public class TodoItem
  {
    public string Uid { get; set; }

    public string Title { get; set; }

    public string Message { get; set; }

    public TodoStatus Status { get; set; }

    public DateTime CreateDate { get; set; }
  }
}

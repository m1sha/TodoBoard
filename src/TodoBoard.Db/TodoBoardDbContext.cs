using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using TodoBoard.Db.Sets;

namespace TodoBoard.Db
{
  public class TodoBoardDbContext: DbContext, ITodoBoardStorage
  {
    public TodoBoardDbContext(DbContextOptions<TodoBoardDbContext> options): base(options)
    {
      
    }

    public TodoDbSet Todos => new TodoDbSet(this, Set<TodoItem>());

    public UserDbSet Users => new UserDbSet(this, Set<User>());

    ITodoRepository ITodoBoardStorage.Todos => Todos;

    IUserRepository ITodoBoardStorage.Users => Users;

    public void CheckConnection()
    {
    }

    public void CreateIfNotExists()
    {
      Database.EnsureCreated();

      var users= new List<User>();
       
      foreach (var name in new[] { "R2D2" , "C3P0", "XB0", "Chubaka" })
      {
        if (Users.DbSet.Any(p=>p.Name == name))
          continue;
        var user = new User { Name = name };
        Users.Add(user);
        users.Add(user);
      }

      if (!users.Any()) return;

      Todos.Add(new TodoItem
      {
        Title = "Update README.md",
        Status = TodoStatus.Finished,
        Message = @"!!! Update README.md\n* Item 1: Todo\n* Item 2: Todo",
        CreateByUser =  users[0],
        AssignToUser = users[1]
      });

      Todos.Add(new TodoItem
      {
        Title = "if default (whitespace) is defined as separator take 2 term parts, ot…",
        Status = TodoStatus.Finished,
        Message = @"!!! Update README.md\n* Item 1: Todo\n* Item 2: Todo",
        CreateByUser = users[1],
        AssignToUser = users[1]
      });

      Todos.Add(new TodoItem
      {
        Title = "Added some more frequency dictionaries",
        Status = TodoStatus.InWork,
        Message = @"!!! Update README.md\n* Item 1: Todo\n* Item 2: Todo",
        CreateByUser = users[1],
        AssignToUser = users[2]
      });

      SaveChanges();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.Entity<TodoItem>().Property(p => p.Title).IsRequired().HasMaxLength(160);
      modelBuilder.Entity<TodoItem>().Property(p => p.Message).HasMaxLength(1000);
      modelBuilder.Entity<TodoItem>().Property(p => p.CreateDate).IsRequired().HasDefaultValueSql("getdate()");
      modelBuilder.Entity<TodoItem>().Property(p => p.ChangeDate).IsRequired().HasDefaultValueSql("getdate()");
      modelBuilder.Entity<User>().Property(p => p.Name).IsRequired().HasMaxLength(60);
    }
  }
  
}

using System;
using System.Collections.Generic;
using System.Linq;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using TodoBoard.Db.Repositories;

namespace TodoBoard.Db
{
  public class DbTodoBoardStorage : ITodoBoardStorage
  {
    private Func<TodoBoardDbContext> dbContextFactory;
    private Lazy<ITodoRepository> todoRepLazy;
    private Lazy<IUserRepository> UserRepLazy;

    public DbTodoBoardStorage(Func<TodoBoardDbContext> dbContextFactory)
    {
      this.dbContextFactory = dbContextFactory;

      todoRepLazy = new Lazy<ITodoRepository>(() => new TodoDbRepository(dbContextFactory));
      UserRepLazy = new Lazy<IUserRepository>(() => new UserDbRepository(dbContextFactory));
    }
    
    public ITodoRepository Todos => todoRepLazy.Value;

    public IUserRepository Users => UserRepLazy.Value;

    public void CheckConnection()
    {
      
    }

    public void CreateIfNotExists()
    {
      using var dbContext = dbContextFactory.Invoke();
      dbContext.Database.EnsureCreated();

      var users = new List<User>();

      foreach (var name in new[] { "R2D2", "C3P0", "XB0", "Chubaka" })
      {
        if (dbContext.Users.Any(p => p.Name == name))
          continue;
        var user = new User { Name = name };
        dbContext.Users.Add(user);
        users.Add(user);
      }

      if (!users.Any()) return;

      dbContext.Todos.Add(new TodoItem
      {
        Title = "Update README.md",
        Status = TodoStatus.Finished,
        Message = @"!!! Update README.md\n* Item 1: Todo\n* Item 2: Todo",
        CreateByUser = users[0],
        AssignToUser = users[1]
      });

      dbContext.Todos.Add(new TodoItem
      {
        Title = "if default (whitespace) is defined as separator take 2 term parts, ot…",
        Status = TodoStatus.Finished,
        Message = @"!!! Update README.md\n* Item 1: Todo\n* Item 2: Todo",
        CreateByUser = users[1],
        AssignToUser = users[1]
      });

      dbContext.Todos.Add(new TodoItem
      {
        Title = "Added some more frequency dictionaries",
        Status = TodoStatus.InWork,
        Message = @"!!! Update README.md\n* Item 1: Todo\n* Item 2: Todo",
        CreateByUser = users[1],
        AssignToUser = users[2]
      });

      dbContext.SaveChanges();
    }
  }
}

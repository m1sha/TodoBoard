using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using TodoBoard.Core.Entities;
using TodoBoard.Core.Storage;
using TodoBoard.Db;

namespace TodoBoard.Tests
{
  [TestClass]
  public class TodoBoardDbContextTest
  {
    private ITodoBoardStorage storage;
    private DbContextOptions<TodoBoardDbContext> options;

    [TestInitialize]
    public void Init()
    {
      options = new DbContextOptionsBuilder<TodoBoardDbContext>()
                   .UseInMemoryDatabase("TodoBoardDb")
                   .EnableSensitiveDataLogging(true)
                   .Options;
      

      storage = new DbTodoBoardStorage(() => new TodoBoardDbContext(options));

    }

    [TestCleanup]
    public void Clear()
    {
      using var context = new TodoBoardDbContext(options);
      context.Database.EnsureDeleted();
    }


    [TestMethod]
    public void Users_Are_Ten()
    {
      for (var i = 0; i < 10; i++)
      {
        var user = new User() { Name = "User " + i };
        storage.Users.AddUser(user).Wait();
      }
      var count = storage.Users.GetList(new UserFilter()).Result.Count();
      Assert.AreEqual(count, 10, "Not 10 users");
    }

    [TestMethod]
    public void Add_User_Success()
    {
      var user = new User() { Name = "User1" };
      var result = storage.Users.AddUser(user).Result;
      Assert.IsNotNull(result, "Result is null");

      var user2 = storage.Users.GetList(new UserFilter()).Result.FirstOrDefault(p => p.Id == new Guid(result));
      Assert.IsNotNull(user2, "Result is null");
    }

    [TestMethod]
    public void Add_Todo_Success()
    {
      var userA = new User() { Name = "User A" };
      var userB = new User() { Name = "User B" };
      storage.Users.AddUser(userA).Wait();
      storage.Users.AddUser(userB).Wait();
      var todoItem = new TodoItem() { Title = "Title", Status = TodoStatus.InWork, AssignToUser = userA, CreateByUser = userB };

      var result = storage.Todos.AddOrUpdate(todoItem).Result;
      Assert.IsNotNull(result, "Didn't added");

      var savedTodoItem = storage.Todos.GetList(new TodoFilter()).Result.First();
      Assert.IsTrue(savedTodoItem.Title == todoItem.Title, "savedTodoItem.Title != todoItem.Title");
    }

    [TestMethod]
    public void Update_Todo_Success()
    {
      var userA = new User() { Name = "User A" };
      var userB = new User() { Name = "User B" };
      storage.Users.AddUser(userA).Wait();
      storage.Users.AddUser(userB).Wait();
      var todoItem = new TodoItem() { Title = "Title", Status = TodoStatus.InWork, AssignToUser = userA, CreateByUser = userB };

      var result = storage.Todos.AddOrUpdate(todoItem).Result;
      Assert.IsNotNull(result, "Didn't added");

      todoItem.Title = "New Title";

      var result2 = storage.Todos.AddOrUpdate(todoItem).Result;
      Assert.IsNotNull(result2, "Didn't updated");

      Assert.AreEqual(result, result2);

      var savedTodoItem = storage.Todos.GetList(new TodoFilter()).Result.First();
      Assert.IsTrue(savedTodoItem.Title == todoItem.Title, "savedTodoItem.Title != todoItem.Title");
    }

    [TestMethod]
    public void Remove_Todo_Success()
    {
      var userA = new User() { Name = "User A" };
      var userB = new User() { Name = "User B" };
      storage.Users.AddUser(userA).Wait();
      storage.Users.AddUser(userB).Wait();
      var todoItem = new TodoItem() { Title = "Title", Status = TodoStatus.InWork, AssignToUser = userA, CreateByUser = userB };

      var result = storage.Todos.AddOrUpdate(todoItem).Result;
      Assert.IsNotNull(result, "Didn't added");

      
      var count = storage.Todos.GetList(new TodoFilter()).Result.Count();
      Assert.IsTrue(count == 1, "Not equals an one");

      storage.Todos.Remove(new[] { result }).Wait();

      count = storage.Todos.GetList(new TodoFilter()).Result.Count();
      Assert.IsTrue(count == 0, "Not equals a zero");
    }

    [TestMethod]
    public void Todos_Are_Ten()
    {
      var userA = new User() { Name = "User A" };
      var userB = new User() { Name = "User B" };
      storage.Users.AddUser(userA).Wait();
      storage.Users.AddUser(userB).Wait();

      for (var i = 0; i < 10; i++)
      {
        var todoItem = new TodoItem() { Title = $"Title {i + 1}", Status = TodoStatus.InWork, AssignToUser = userA, CreateByUser = userB };
        storage.Todos.AddOrUpdate(todoItem).Wait();
      }

      var count = storage.Todos.GetList(new TodoFilter()).Result.Count();

      Assert.AreEqual(count, 10, "Not 10 todos");
    }

  }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoBoard.Db
{
  public class TodoBoardDbContextFactory : IDesignTimeDbContextFactory<TodoBoardDbContext>
  {
    public TodoBoardDbContext CreateDbContext(string[] args)
    {
      var connStr = "Database=test_db_1;Server=.\\SQLEXPRESS;Trusted_Connection=True;MultipleActiveResultSets=true";
      var optionsBuilder = new DbContextOptionsBuilder<TodoBoardDbContext>();
      optionsBuilder.UseSqlServer(connStr, p => p.MigrationsAssembly("TodoBoard.Db"));
      return new TodoBoardDbContext(optionsBuilder.Options);
    }
  }
}

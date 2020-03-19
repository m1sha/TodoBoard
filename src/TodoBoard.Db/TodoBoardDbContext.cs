using Microsoft.EntityFrameworkCore;
using TodoBoard.Core.Entities;


namespace TodoBoard.Db
{
  public class TodoBoardDbContext: DbContext
  {
    public TodoBoardDbContext(DbContextOptions<TodoBoardDbContext> options): base(options)
    {
      
    }

    public DbSet<TodoItem> Todos { get; set; }

    public DbSet<User> Users { get; set; }

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

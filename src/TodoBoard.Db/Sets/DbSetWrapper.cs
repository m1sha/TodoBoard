using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace TodoBoard.Db.Sets
{
  public class DbSetWrapper<T>: DbSet<T> where T : class
  {
    public DbSet<T> DbSet { get; }

    protected DbContext Context { get; }

    public DbSetWrapper(DbContext context, DbSet<T> dbSet)
    {
      DbSet = dbSet;
      Context = context;
    }

    public override EntityEntry<T> Add(T entity)
      => DbSet.Add(entity);

    public override ValueTask<EntityEntry<T>> AddAsync(T entity, CancellationToken cancellationToken = default)
      => DbSet.AddAsync(entity, cancellationToken);

    public override void AddRange(params T[] entities)
      => DbSet.AddRange(entities);

    public override void AddRange(IEnumerable<T> entities)
      => DbSet.AddRange(entities);

    public override Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default)
      => DbSet.AddRangeAsync(entities, cancellationToken);

    public override Task AddRangeAsync(params T[] entities)
      => DbSet.AddRangeAsync(entities);

    public override IAsyncEnumerable<T> AsAsyncEnumerable()
      => DbSet.AsAsyncEnumerable();

    public override IQueryable<T> AsQueryable()
      => DbSet.AsQueryable();

    public override EntityEntry<T> Attach(T entity)
      => DbSet.Attach(entity);

    public override void AttachRange(IEnumerable<T> entities)
      => DbSet.AttachRange(entities);

    public override void AttachRange(params T[] entities)
      => DbSet.AttachRange(entities);

    public override bool Equals(object obj)
      => DbSet.Equals(obj);

    public override T Find(params object[] keyValues)
      => DbSet.Find(keyValues);

    public override ValueTask<T> FindAsync(object[] keyValues, CancellationToken cancellationToken)
      => DbSet.FindAsync(keyValues, cancellationToken);

    public override ValueTask<T> FindAsync(params object[] keyValues)
      => DbSet.FindAsync(keyValues);

    public override int GetHashCode()
      => DbSet.GetHashCode();

    public override LocalView<T> Local => DbSet.Local;

    public override EntityEntry<T> Remove(T entity)
      => DbSet.Remove(entity);

    public override void RemoveRange(IEnumerable<T> entities)
      => DbSet.RemoveRange(entities);

    public override void RemoveRange(params T[] entities)
      => DbSet.RemoveRange(entities);

    public override string ToString()
      => DbSet.ToString();

    public override EntityEntry<T> Update(T entity)
      => DbSet.Update(entity);

    public override void UpdateRange(IEnumerable<T> entities)
      => DbSet.UpdateRange(entities);

    public override void UpdateRange(params T[] entities)
      => DbSet.UpdateRange(entities);
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services
{
    public interface IRepository<TEntity>
    {
        /// <summary>
        /// Used to get a IQueryable that is used to retrieve entities from entire table.
        /// </summary>
        /// <returns>IQueryable to be used to select entities from database</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>Used to get all entities.</summary>
        /// <returns>List of all entities</returns>
        Task<List<TEntity>> GetAllListAsync();

        /// <summary>Inserts a new entity.</summary>
        /// <param name="entity">Inserted entity</param>
        Task<TEntity> InsertAsync(TEntity entity);

        /// <summary>Deletes an entity.</summary>
        /// <param name="entity">Entity to be deleted</param>
        Task DeleteAsync(TEntity entity);

        /// <summary>Deletes all entities.</summary>
        Task DeleteAllAsync();
    }

    public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
    {
        public abstract IQueryable<TEntity> GetAll();

        public Task<List<TEntity>> GetAllListAsync()
            => Task.FromResult(GetAll().ToList());

        protected abstract TEntity Insert(TEntity entity);

        public Task<TEntity> InsertAsync(TEntity entity)
            => Task.FromResult<TEntity>(this.Insert(entity));

        protected abstract void Delete(TEntity entity);

        public Task DeleteAsync(TEntity entity)
        {
            this.Delete(entity);
            return Task.CompletedTask;
        }

        protected abstract void DeleteAll();

        public Task DeleteAllAsync()
        {
            this.DeleteAll();
            return Task.CompletedTask;
        }

    }

    public class EfCoreRepositoryBase<TDbContext, TEntity> : RepositoryBase<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {
        /// <summary>
        /// Gets EF DbContext object.
        /// </summary>
        public virtual TDbContext GetContext()
        {
            return _dbContextProvider.GetDbContext();
        }

        /// <summary>
        /// Gets DbSet for given entity.
        /// </summary>
        public virtual DbSet<TEntity> GetTable()
        {
            var context = GetContext();
            return context.Set<TEntity>();
        }

        protected virtual IQueryable<TEntity> GetQueryable()
        {
            return GetTable().AsQueryable();
        }

        private readonly IDbContextProvider<TDbContext> _dbContextProvider;

        public EfCoreRepositoryBase(IDbContextProvider<TDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        public override IQueryable<TEntity> GetAll()
        {
            return GetAllIncluding();
        }

        protected IQueryable<TEntity> GetAllIncluding(
            params Expression<Func<TEntity, object>>[] propertySelectors)
        {
            var query = GetQueryable();

            return propertySelectors.IsNullOrEmpty()
                ? query
                : propertySelectors.Aggregate(query,
                    (current,
                        propertySelector)
                            => current.Include(propertySelector));
        }


        protected override TEntity Insert(TEntity entity)
        {
            entity = GetTable().Add(entity).Entity;

            Save();

            return entity;
        }

        protected override void Delete(TEntity entity)
        {
            AttachIfNot(entity);
            GetTable().Remove(entity);

            Save();
        }

        protected override void DeleteAll()
        {
            GetContext().RemoveRange(GetTable());

            Save();
        }

        private void Save()
        {
            GetContext().SaveChanges();
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            var entry = GetContext().ChangeTracker.Entries()
                .FirstOrDefault(ent => ent.Entity == entity);

            if (entry != null)
            {
                return;
            }

            GetTable().Attach(entity);
        }
    }

    /// <summary>Extension methods for Collections.</summary>
    public static class CollectionExtensions
    {
        /// <summary>
        /// Checks whatever given collection object is null or has no item.
        /// </summary>
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
            => source == null || source.Count <= 0;
    }
}
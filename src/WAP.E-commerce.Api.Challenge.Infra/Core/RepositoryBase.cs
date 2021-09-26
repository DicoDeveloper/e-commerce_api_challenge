using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Core.Repositories;

namespace WAP.E_commerce.Api.Challenge.Infra.Core
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        internal const string ConnectionStringName = "DefaultConnection";
        internal WAPContext context;
        internal DbSet<TEntity> dbSet;
        protected IConfiguration Config;
        protected string TableName;

        public RepositoryBase(WAPContext context, IConfiguration config, string tableName)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
            this.Config = config;
            this.TableName = tableName;
        }

        public virtual async Task<TEntity> ReadAsync(long id)
        {
            var entity = await dbSet.FindAsync(id);
            if (entity != null) await context.Entry(entity).ReloadAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> ReadAsync(int skip, int take)
        {
            return await dbSet.Where(x => !x.Removed).OrderBy(x => x.CreatedAt).Skip(skip).Take(take).ToListAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> ReadAsyncWithRemoved(int skip, int take)
        {
            return await dbSet.OrderBy(x => x.CreatedAt).Skip(skip).Take(take).ToListAsync();
        }
    }
}
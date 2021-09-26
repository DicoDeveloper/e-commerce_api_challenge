using System.Collections.Generic;
using System.Threading.Tasks;
using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<TEntity> ReadAsync(long id);
        Task<IEnumerable<TEntity>> ReadAsync(int skip, int take);
    }
}
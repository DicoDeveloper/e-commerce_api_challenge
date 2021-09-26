using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Core.Repositories;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Handlers
{
    public abstract class HandlerBase<T, TR> where T : Entity where TR : IRepositoryBase<T>
    {
        protected readonly TR repository;

        protected HandlerBase(TR repository)
        {
            this.repository = repository;
        }
    }
}
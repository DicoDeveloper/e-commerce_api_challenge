using Flunt.Notifications;
using Flunt.Validations;
using MediatR;
using WAP.E_commerce.Api.Challenge.Domain.Core.Handlers;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Queries
{
    public abstract class Query : Notifiable, IValidatable
    {
        public abstract void Validate();
    }

    public abstract class Query<T> : Notifiable, IValidatable, IRequest<ResultResponse<T>> where T : class
    {
        public abstract void Validate();
    }
}
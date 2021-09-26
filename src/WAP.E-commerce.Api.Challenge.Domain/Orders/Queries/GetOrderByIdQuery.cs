using Flunt.Validations;
using MediatR;
using WAP.E_commerce.Api.Challenge.Domain.Core.Handlers;
using WAP.E_commerce.Api.Challenge.Domain.Core.Queries;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Dtos;

namespace WAP.E_commerce.Api.Challenge.Domain.Orders.Queries
{
    public class GetOrderByIdQuery : GetByIdQuery, IRequest<ResultResponse<OrderDto>>
    {
        public override void Validate()
        {
            var contract = new Contract()
                .IsLowerOrEqualsThan(0, Id, nameof(Id), "O campo Id precisa ser passado na URL e precisa ser maior que 0");
            AddNotifications(contract);
        }
    }
}
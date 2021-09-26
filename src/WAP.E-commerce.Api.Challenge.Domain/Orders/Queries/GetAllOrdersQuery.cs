using MediatR;
using WAP.E_commerce.Api.Challenge.Domain.Core.Handlers;
using WAP.E_commerce.Api.Challenge.Domain.Core.Queries;

namespace WAP.E_commerce.Api.Challenge.Domain.Orders.Queries
{
    public class GetAllOrdersQuery : GetAllQuery, IRequest<ResultResponse>
    {
        public override void Validate()
        {

        }
    }
}
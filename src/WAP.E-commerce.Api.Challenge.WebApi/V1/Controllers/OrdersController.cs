using MediatR;
using Microsoft.Extensions.Logging;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Queries;
using WAP.E_commerce.Api.Challenge.WebApi.V1.Core;

namespace WAP.E_commerce.Api.Challenge.WebApi.V1.Controllers
{
    public class OrdersController : BaseController<
        OrderDto,
        GetAllOrdersQuery,
        GetOrderByIdQuery>
    {
        public OrdersController(ILogger<OrdersController> logger, IMediator mediator) : base(logger, mediator) { }
    }
}
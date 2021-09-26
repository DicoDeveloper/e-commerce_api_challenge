using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Omu.ValueInjecter;
using WAP.E_commerce.Api.Challenge.Domain.Addresses.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.Core.Handlers;
using WAP.E_commerce.Api.Challenge.Domain.Core.Interfaces;
using WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Queries;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;

namespace PayPow.Platform.Backend.Domain.Addresses.Handlers
{
    public class OrderQueryHandler : HandlerBase<Order, IOrderRepository>,
        IRequestHandler<GetAllOrdersQuery, ResultResponse>,
        IRequestHandler<GetOrderByIdQuery, ResultResponse<OrderDto>>
    {
        public OrderQueryHandler(IUoWRepository uoWRepository) : base(uoWRepository.OrderRepository)
        {
        }

        public async Task<ResultResponse> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
        {
            var query = await repository.ReadAllAsync(request.Skip, request.Take);
            var data = (from o in query.orders
                        select new OrderDto
                        {
                            Id = o.Id,
                            CreatedAt = o.CreatedAt.DateTime,
                            Number = o.Number,
                            Deliverydate = o.Deliverydate,
                            TotalValue = o.TotalValue,
                            DeliveryAddress = Mapper.Map<AddressDto>(o.DeliveryAddress),
                            Items = o.Items.Select(x => Mapper.Map<OrderItemDto>(x)),
                            DeliveryTeam = Mapper.Map<DeliveryTeamDto>(o.DeliveryTeam),
                        });
            return new ResultResponse(new
            {
                Orders = data,
                TotalCount = query.totalOrders,
            });
        }

        public async Task<ResultResponse<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var data = Mapper.Map<OrderDto>(await repository.ReadAsync(request.Id));
            return new ResultResponse<OrderDto>(data);
        }
    }
}
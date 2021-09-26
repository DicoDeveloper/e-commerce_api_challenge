using Microsoft.Extensions.Configuration;
using WAP.E_commerce.Api.Challenge.Infra.Core;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;

namespace WAP.E_commerce.Api.Challenge.Infra.Repositories
{
    public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(WAPContext context, IConfiguration config) : base(context, config, "ORDERS_ITEMS")
        {
        }
    }
}
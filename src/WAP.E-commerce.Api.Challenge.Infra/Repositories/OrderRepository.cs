using Microsoft.Extensions.Configuration;
using WAP.E_commerce.Api.Challenge.Infra.Core;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WAP.E_commerce.Api.Challenge.Infra.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(WAPContext context, IConfiguration config) : base(context, config, "ORDERS")
        {
        }

        public override async Task<IEnumerable<Order>> ReadAsync(int skip, int take)
        {
            return await dbSet.Where(o => !o.Removed).Include(o => o.DeliveryTeam).Include(o => o.DeliveryAddress).Include(o => o.Items)
                              .OrderByDescending(o => o.CreatedAt).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<(int totalOrders, IEnumerable<Order> orders)> ReadAllAsync(int skip, int take)
        {
            IQueryable<Order> query = dbSet.Where(o => !o.Removed).Include(o => o.DeliveryTeam).Include(o => o.DeliveryAddress).Include(o => o.Items)
                                           .OrderByDescending(o => o.CreatedAt);

            return (await query.CountAsync(), await query.Skip(skip).Take(take).ToListAsync());
        }
    }
}
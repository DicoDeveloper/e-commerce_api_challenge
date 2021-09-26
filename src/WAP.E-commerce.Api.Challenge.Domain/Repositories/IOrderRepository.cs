using System.Collections.Generic;
using System.Threading.Tasks;
using WAP.E_commerce.Api.Challenge.Domain.Core.Repositories;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;

namespace WAP.E_commerce.Api.Challenge.Domain.Repositories
{
    public interface IOrderRepository : IRepositoryBase<Order>
    {
        Task<(int totalOrders, IEnumerable<Order> orders)> ReadAllAsync(int skip, int take);
    }
}
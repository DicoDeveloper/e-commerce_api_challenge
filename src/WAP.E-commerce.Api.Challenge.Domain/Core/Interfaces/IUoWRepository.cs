using System;
using System.Threading.Tasks;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Interfaces
{
    public interface IUoWRepository : IDisposable
    {
        IAddressRepository AddressRepository { get; }
        IDeliveryTeamRepository DeliveryTeamRepository { get; }
        IOrderRepository OrderRepository { get; }
        IOrderItemRepository OrderItemRepository { get; }
        Task CommitAsync();
        Task RollbackAsync();
    }
}

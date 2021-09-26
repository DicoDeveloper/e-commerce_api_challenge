using System;
using System.Threading.Tasks;
using WAP.E_commerce.Api.Challenge.Domain.Core.Interfaces;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;

namespace WAP.E_commerce.Api.Challenge.Infra.Repositories
{
    public class UoWRepository : IUoWRepository
    {

        private readonly WAPContext context;

        public UoWRepository(
            WAPContext context,
            IAddressRepository addressRepository,
            IDeliveryTeamRepository deliveryTeamRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository)
        {
            this.context = context;
            AddressRepository = addressRepository;
            DeliveryTeamRepository = deliveryTeamRepository;
            OrderRepository = orderRepository;
            OrderItemRepository = orderItemRepository;
        }

        public IAddressRepository AddressRepository { get; }
        public IDeliveryTeamRepository DeliveryTeamRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IOrderItemRepository OrderItemRepository { get; }

        public async Task CommitAsync()
        {
            await context.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await context.DisposeAsync();
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}

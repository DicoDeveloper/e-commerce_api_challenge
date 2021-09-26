using Microsoft.Extensions.DependencyInjection;
using WAP.E_commerce.Api.Challenge.Infra.Repositories;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;
using WAP.E_commerce.Api.Challenge.Domain.Core.Interfaces;

namespace WAP.E_commerce.Api.Challenge.WebApi.Extensions
{
    public static class RepositoryExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IAddressRepository, AddressRepository>();
            services.AddTransient<IDeliveryTeamRepository, DeliveryTeamRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IUoWRepository, UoWRepository>();
        }
    }
}
using Microsoft.Extensions.Configuration;
using WAP.E_commerce.Api.Challenge.Infra.Core;
using WAP.E_commerce.Api.Challenge.Domain.Addresses.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;

namespace WAP.E_commerce.Api.Challenge.Infra.Repositories
{
    public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(WAPContext context, IConfiguration config) : base(context, config, "ADDRESSES")
        {
        }
    }
}
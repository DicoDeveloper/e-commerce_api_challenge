using Microsoft.Extensions.Configuration;
using WAP.E_commerce.Api.Challenge.Infra.Core;
using WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Repositories;

namespace WAP.E_commerce.Api.Challenge.Infra.Repositories
{
    public class DeliveryTeamRepository : RepositoryBase<DeliveryTeam>, IDeliveryTeamRepository
    {
        public DeliveryTeamRepository(WAPContext context, IConfiguration config) : base(context, config, "DELIVERY_TEAMS")
        {
        }
    }
}
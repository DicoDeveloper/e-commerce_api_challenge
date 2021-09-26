using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;

namespace WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Entities
{
    public class DeliveryTeam : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VehicleLicensePlate { get; set; }
    }
}
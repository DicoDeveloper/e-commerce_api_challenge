using WAP.E_commerce.Api.Challenge.Domain.Core.Dtos;

namespace WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Dtos
{
    public class DeliveryTeamDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string VehicleLicensePlate { get; set; }
    }
}
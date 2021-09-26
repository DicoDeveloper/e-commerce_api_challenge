using System;
using System.Collections.Generic;
using WAP.E_commerce.Api.Challenge.Domain.Addresses.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.Core.Dtos;
using WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Dtos;

namespace WAP.E_commerce.Api.Challenge.Domain.Orders.Dtos
{
    public class OrderDto : BaseDto
    {
        public long Number { get; set; }
        public DateTime? Deliverydate { get; set; }
        public string TotalValue { get; set; }
        public AddressDto DeliveryAddress { get; set; }
        public IEnumerable<OrderItemDto> Items { get; set; }
        public DeliveryTeamDto DeliveryTeam { get; set; }
    }
}
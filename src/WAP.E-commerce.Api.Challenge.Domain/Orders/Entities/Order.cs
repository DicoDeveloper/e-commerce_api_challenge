using System;
using System.Collections.Generic;
using WAP.E_commerce.Api.Challenge.Domain.Addresses.Entities;
using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;
using WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Entities;

namespace WAP.E_commerce.Api.Challenge.Domain.Orders.Entities
{
    public class Order : Entity
    {
        public long Number { get; set; }
        public DateTime? Deliverydate { get; set; }
        public string TotalValue { get; set; }
        public Address DeliveryAddress { get; set; }
        public IList<OrderItem> Items { get; set; }
        public DeliveryTeam DeliveryTeam { get; set; }
    }
}
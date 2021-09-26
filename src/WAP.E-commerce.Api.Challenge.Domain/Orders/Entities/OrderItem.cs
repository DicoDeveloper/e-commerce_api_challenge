using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;

namespace WAP.E_commerce.Api.Challenge.Domain.Orders.Entities
{
    public class OrderItem : Entity
    {
        public Order Order { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
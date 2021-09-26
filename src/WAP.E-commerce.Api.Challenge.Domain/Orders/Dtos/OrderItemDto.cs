using WAP.E_commerce.Api.Challenge.Domain.Core.Dtos;

namespace WAP.E_commerce.Api.Challenge.Domain.Orders.Dtos
{
    public class OrderItemDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public decimal Value { get; set; }
    }
}
using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;

namespace WAP.E_commerce.Api.Challenge.Domain.Addresses.Entities
{
    public class Address : Entity
    {
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string Complement { get; set; }
        public string City { get; set; }
        public string State { get; set; }
    }
}
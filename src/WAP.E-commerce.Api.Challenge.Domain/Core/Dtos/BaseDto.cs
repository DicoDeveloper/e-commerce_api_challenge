using System;

namespace WAP.E_commerce.Api.Challenge.Domain.Core.Dtos
{
    public abstract class BaseDto
    {
        public long Id { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAP.E_commerce.Api.Challenge.Domain.Core.Entities;

namespace WAP.E_commerce.Api.Challenge.Infra.Core
{
    public class EntityConfiguration<T> where T : Entity
    {
        public virtual void DefaultConfigurations(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt).IsRequired();
            builder.Property(x => x.Active).IsRequired();
            builder.Property(x => x.Removed).IsRequired();
        }
    }
}
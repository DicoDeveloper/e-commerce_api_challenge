using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAP.E_commerce.Api.Challenge.Domain.Addresses.Entities;
using WAP.E_commerce.Api.Challenge.Infra.Core;

namespace WAP.E_commerce.Api.Challenge.Infra.EntityConfigurations
{
    public class AddressConfiguration : EntityConfiguration<Address>, IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.ToTable("ADDRESS");
            DefaultConfigurations(builder);

            builder.Property(x => x.PostCode).HasMaxLength(15);
            builder.Property(x => x.Street).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Number).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Neighborhood).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Complement).HasMaxLength(255);
            builder.Property(x => x.City).HasMaxLength(255).IsRequired();
            builder.Property(x => x.State).IsRequired();
        }
    }
}
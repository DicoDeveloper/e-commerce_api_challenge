using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;
using WAP.E_commerce.Api.Challenge.Infra.Core;

namespace WAP.E_commerce.Api.Challenge.Infra.EntityConfigurations
{
    public class OrderConfiguration : EntityConfiguration<Order>, IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("ORDERS");
            DefaultConfigurations(builder);

            builder.Property(x => x.Deliverydate);
            builder.Property(x => x.Number).IsRequired();
            builder.Property(x => x.TotalValue).IsRequired();

            builder.HasOne(x => x.DeliveryAddress).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.DeliveryTeam).WithMany().OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(x => x.Items).WithOne(x => x.Order).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
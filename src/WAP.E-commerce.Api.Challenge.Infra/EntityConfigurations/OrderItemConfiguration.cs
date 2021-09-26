using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAP.E_commerce.Api.Challenge.Domain.Orders.Entities;
using WAP.E_commerce.Api.Challenge.Infra.Core;

namespace WAP.E_commerce.Api.Challenge.Infra.EntityConfigurations
{
    public class OrderItemConfiguration : EntityConfiguration<OrderItem>, IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("ORDERS_ITEMS");
            DefaultConfigurations(builder);

            builder.Property(x => x.Description);
            builder.Property(x => x.Name).HasMaxLength(155).IsRequired();
            builder.Property(x => x.Quantity).IsRequired();
            builder.Property(x => x.Value).IsRequired();

            builder.HasOne(x => x.Order).WithMany(x => x.Items).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
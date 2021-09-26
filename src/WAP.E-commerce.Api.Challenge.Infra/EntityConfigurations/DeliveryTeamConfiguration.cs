using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WAP.E_commerce.Api.Challenge.Domain.DeliveryTeams.Entities;
using WAP.E_commerce.Api.Challenge.Infra.Core;

namespace WAP.E_commerce.Api.Challenge.Infra.EntityConfigurations
{
    public class DeliveryTeamConfiguration : EntityConfiguration<DeliveryTeam>, IEntityTypeConfiguration<DeliveryTeam>
    {
        public void Configure(EntityTypeBuilder<DeliveryTeam> builder)
        {
            builder.ToTable("DELIVERY_TEAMS");
            DefaultConfigurations(builder);

            builder.Property(x => x.Description).HasMaxLength(255);
            builder.Property(x => x.Name).HasMaxLength(155).IsRequired();
            builder.Property(x => x.VehicleLicensePlate).HasMaxLength(50).IsRequired();
        }
    }
}
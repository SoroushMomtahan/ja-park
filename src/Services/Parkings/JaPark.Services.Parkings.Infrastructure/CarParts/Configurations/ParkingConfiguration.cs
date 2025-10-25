using JaPark.Services.Parkings.Domain.CarParts.Models;
using JaPark.Services.Parkings.Domain.CarParts.ValueObjects;
using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Parkings.Infrastructure.CarParts.Configurations;

internal sealed class ParkingConfiguration : IEntityTypeConfiguration<Parking>
{
    public void Configure(EntityTypeBuilder<Parking> builder)
    {
        builder.HasKey(parking => parking.Id);
        builder.Property(parking => parking.Id).HasConversion(
            id => id.Value, valueFromDb => PrefixedGuidV3.From<ParkingId>(valueFromDb).Value);
        builder.ComplexProperty(parking => parking.Name, nameBuilder =>
        {
            nameBuilder.Property(name => name.Value)
                .HasColumnName("Name");
        });
        builder.Property(parking => parking.Type).HasConversion<string>();
        builder.OwnsMany(parking => parking.Sections).ToJson();
        builder.OwnsOne(parking => parking.Address).ToJson(); // we can use complexProperty if need column for each property 
        builder.ComplexProperty(parking => parking.Subscription, subscriptionBuilder =>
        {
            subscriptionBuilder.Property(subscription => subscription.MaxAcceptableSection);
            subscriptionBuilder.Property(subscription => subscription.MaxAcceptableSpace);
        });
    }
}

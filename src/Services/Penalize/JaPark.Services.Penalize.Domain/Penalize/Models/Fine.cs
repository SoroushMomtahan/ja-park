using JaPark.Services.Penalize.Domain.Penalize.ValueObjects;
using JaPark.Shared.Domain.PrefixedGuidTools;

namespace JaPark.Services.Penalize.Domain.Penalize.Models;

public sealed class Fine : Aggregate
{
    public FineId Id { get; private set; }
    public PlateNumber PlateNumber { get; private set; }
    public FineDescription FineDescription { get; private set; }
    
    private Fine() {}

    public static Fine Create(PlateNumber plateNumber, FineDescription fineDescription)
    {
        FineId fineId = PrefixedGuidV3.New<FineId>();
        return new Fine
        {
            Id = fineId,
            PlateNumber = plateNumber,
            FineDescription = fineDescription,
        };
    }
}

namespace JaPark.Services.Booking.Domain.Spaces.ValueObjects;

public enum SpaceStatusType
{
    Available,
    Unavailable,
    Reserved
}

public record SpaceStatus
{
    public SpaceStatusType StatusType { get; init; }
    private SpaceStatus(SpaceStatusType statusType) => StatusType = statusType;
    public static readonly SpaceStatus Available = new(SpaceStatusType.Available);
    public static readonly SpaceStatus Unavailable = new(SpaceStatusType.Unavailable);
    public static readonly SpaceStatus Reserved = new(SpaceStatusType.Reserved);
    public static readonly SpaceStatus Default = new(SpaceStatusType.Available);
}

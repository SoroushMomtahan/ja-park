namespace JaPark.Services.Parkings.Domain.CarParts.ValueObjects;

public sealed record ParkingSection
{
    public int Number { get; }
    public int Capacity { get; }
    
    private ParkingSection(){}

    private ParkingSection(int number, int capacity) => (Number, Capacity) = (number,  capacity);

    public static ParkingSection From(int number, int capacity)
    {
        return new ParkingSection(number, capacity);
    }
}

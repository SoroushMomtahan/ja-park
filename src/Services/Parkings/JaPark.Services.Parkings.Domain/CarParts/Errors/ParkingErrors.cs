using JaPark.Shared.Domain.Errors;

namespace JaPark.Services.Parkings.Domain.CarParts.Errors;

public static class ParkingErrors
{
    public static readonly Error NullOrEmptyParkingName = new(
        "ParkingErrors.NullOrEmptyParkingName",
        "پارکینگ حتما باید یک نام داشته باشد.",
        ErrorType.Validation);

    public static readonly Error SectionAlreadyAdded = new(
        "ParkingErrors.SectionAlreadyAdded",
        "این بخش قبلا اضافه شده است.",
        ErrorType.Conflict);

    public static readonly Error MoreSectionNotAcceptable = new(
        "ParkingErrors.MoreSectionNotAcceptable",
        "امکان اضافه کردن بخش بیشتری وجود ندارد.",
        ErrorType.Failure);

    public static readonly Error SectionNotFound = new(
        "ParkingErrors.SectionNotFound",
        "بخشی با این اطلاعات یافت نشد.",
        ErrorType.NotFound);
    public static Error MoreSpaceNotAcceptable(int remainingSpace) => new(
        "ParkingErrors.MoreSpaceNotAcceptable",
        $"تنها {remainingSpace} جای خالی باقی مانده است.",
        ErrorType.Failure);
}

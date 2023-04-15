namespace Sources.App.Data.Cars
{
    public enum CarType
    {
        Taxi = 0,
        Ambulance = 1,
        FireEngine = 2,
        Police = 3,
        Sport = 4,
        Sedan = 5,
        Pickup = 6,
        Hatchback = 7,
        Suv = 8,
        Bus = 9,
    }

    public static class CarTypeExtensions
    {
        public static bool IsColorable(this CarType carType) =>
            carType is CarType.Sport or CarType.Sedan or CarType.Pickup or CarType.Hatchback or CarType.Suv or CarType.Bus;
    }
}
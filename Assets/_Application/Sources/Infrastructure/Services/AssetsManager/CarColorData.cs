namespace Sources.Infrastructure.Services.Balance
{
    public class CarColorData
    {
        public CarType CarType { get; }
        public CarColorType? CarColor { get; }

        public CarColorData(CarType carType, CarColorType? carColor)
        {
            CarType = carType;
            CarColor = carColor;
        }
    }
}
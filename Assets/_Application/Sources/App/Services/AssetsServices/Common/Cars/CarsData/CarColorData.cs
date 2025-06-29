namespace Sources.App.Services.AssetsServices.Common.Cars.CarsData
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
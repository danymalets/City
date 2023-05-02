using Scellecs.Morpeh;

namespace Sources.App.Data.Cars
{
    public class CarPlaceData
    {
        public Entity Car;
        public int Place;

        public CarPlaceData(Entity car, int place)
        {
            Car = car;
            Place = place;
        }
    }
}
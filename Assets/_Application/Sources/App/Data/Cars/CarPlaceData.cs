using Scellecs.Morpeh;

namespace Sources.App.Data.Cars
{
    public struct CarPlaceData
    {
        public Entity Car { get; }
        public int Place { get; }

        public CarPlaceData(Entity car, int place)
        {
            Car = car;
            Place = place;
        }
    }
}
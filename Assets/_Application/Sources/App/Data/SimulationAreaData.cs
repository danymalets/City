using Sources.Utils.CommonUtils.Extensions;
using UnityEngine;

namespace Sources.App.Data
{
    public readonly struct SimulationAreaData
    {
        private readonly SimulationShapeData _smallShape;
        private readonly SimulationShapeData _bigShape;
        public Vector2 Center { get; }

        public SimulationAreaData(Vector2 center, Vector2 normalDirection, SimulationBordersData borders)
        {
            Center = center;
            _smallShape = new SimulationShapeData(center, normalDirection, borders.Radius, borders.BackDistance);
            _bigShape = new SimulationShapeData(center, normalDirection,
                borders.Radius + borders.Delta, borders.BackDistance + borders.Delta);
        }


        public bool IsInsideSmall(Vector3 point) =>
            _smallShape.IsInside(point.GetXZ());
        
        public bool IsInsideBig(Vector3 point) =>
            _bigShape.IsInside(point.GetXZ());
    }
}
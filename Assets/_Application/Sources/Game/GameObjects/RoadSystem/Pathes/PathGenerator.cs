using System.Collections.Generic;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public abstract class PathGenerator : MonoBehaviour
    {
        public abstract IEnumerable<Path> Generate();
    }
}
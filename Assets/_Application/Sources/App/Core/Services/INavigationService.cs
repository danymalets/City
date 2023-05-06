using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Data.Common
{
    public interface INavigationService : IService
    {
        bool TryGetPlayerPath(Vector3 source, Vector3 target, out Vector3[] path);

        bool TryGetCarPath(Vector3 source, Vector3 target, out Vector3[] path);
    }
}
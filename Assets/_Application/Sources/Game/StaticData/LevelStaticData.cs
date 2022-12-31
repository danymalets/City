using Sources.Game.Cameras;
using UnityEngine;

namespace Sources.Game.StaticData
{
    public class LevelStaticData : MonoBehaviour
    {
        public GameCamera GameCamera => FindObjectOfType<GameCamera>();
    }
}
using System.Linq;
using Sources.App.Services.AssetsServices.Common.Cars.CarsData;
using Sources.App.Services.AssetsServices.Constants;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.MorpehWrapper.DefaultComponents.Monos;
using TriInspector;

namespace Sources.App.Services.AssetsServices.Common.MonoEntities.Car
{
    public partial class CarMonoEntity
    {
        [Button("Bake")]
        private void Bake()
        {
            base.OnValidate();

            _transform = GetComponent<SafeTransform>();
            _enableableGameObject = GetComponent<EnableableGameObject>();
            _rigidbodySwitcher = GetComponent<RigidbodySwitcher>();
            _wheelsSystem = GetComponentInChildren<WheelsSystem>();
            _enterPoints = GetComponentInChildren<CarEnterPoints>();
            _carBorders = GetComponentInChildren<CarBorders>();
            _meshRenderers = GetComponentsInChildren<SafeMeshRenderer>();
            _carObstacles = GetComponentInChildren<CarObstacles>();
            _colliders = GetComponentsInChildren<SafeColliderBase>()
                .ExceptOne(_carBorders.SafeBoxCollider).ToArray();
            
            _wheelsSystem.DisableSystem();

            gameObject.SetLayerRecursive(Layers.Car);

            _carBorders.SafeBoxCollider.IsTrigger = false;
            _carBorders.SafeBoxCollider.Layer = Layers.CarBorders;
        }

        [Button("Set auto borders (do not use multi-click on this button)")]
        private void SetAutoBorders() => 
            _carBorders.SetupBounds(_colliders);
        
        [Button("Set auto obstacles (do not use multi-click on this button)")]
        private void SetAutoObstacles() => 
            _carObstacles.SetupBounds(_colliders);
    }
}
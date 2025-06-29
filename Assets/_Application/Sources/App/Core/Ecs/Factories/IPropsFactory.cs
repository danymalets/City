using Scellecs.Morpeh;
using Sources.App.Services.AssetsServices.Common.MonoEntities.Props;
using Sources.Utils.Di;

namespace Sources.App.Core.Ecs.Factories
{
    public interface IPropsFactory : IService
    {
        Entity Create(PropsMonoEntity propsMonoEntity);
    }
}
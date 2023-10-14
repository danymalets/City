using Sources.App.Ui.Base.Controllers;
using Sources.Utils.Di;

namespace Sources.App.Ui.Base
{
    public interface IUiControllersService : IService
    {
        TWindowController Get<TWindowController>() where TWindowController : ScreenControllerBase;
    }
}
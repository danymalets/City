using Sources.Utils.Di;

namespace Sources.App.Ui.Controllers
{
    public interface IUiControllersService : IService
    {
        TWindowController Get<TWindowController>() where TWindowController : ScreenControllerBase;
    }
}
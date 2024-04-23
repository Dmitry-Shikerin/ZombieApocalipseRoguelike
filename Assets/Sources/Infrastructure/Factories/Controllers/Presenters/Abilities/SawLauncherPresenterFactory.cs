using Sources.Controllers.Abilities;
using Sources.Controllers.Common;
using Sources.Domain.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;

namespace Sources.Infrastructure.Factories.Controllers.Abilities
{
    public class SawLauncherPresenterFactory
    {
        public SawLauncherPresenter Create(
            SawLauncher sawLauncher,
            ISawLauncherView sawLauncherView)
        {
            return new SawLauncherPresenter(sawLauncher, sawLauncherView);
        }
    }
}
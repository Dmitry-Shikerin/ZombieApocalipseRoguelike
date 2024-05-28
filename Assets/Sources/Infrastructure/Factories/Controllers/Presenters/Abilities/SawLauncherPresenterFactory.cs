using Sources.Controllers.Presenters.Abilities;
using Sources.Domain.Models.Abilities;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Abilities
{
    public class SawLauncherPresenterFactory
    {
        public SawLauncherPresenter Create(SawLauncher sawLauncher) =>
            new(sawLauncher);
    }
}
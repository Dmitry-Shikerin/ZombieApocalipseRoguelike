using System;
using Sources.Controllers.Abilities;
using Sources.Domain.Abilities;
using Sources.Infrastructure.Factories.Controllers.Abilities;
using Sources.Presentations.Views.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;

namespace Sources.Infrastructure.Factories.Views.Abilities
{
    public class SawLauncherViewFactory
    {
        private readonly SawLauncherPresenterFactory _sawLauncherPresenterFactory;

        public SawLauncherViewFactory(SawLauncherPresenterFactory sawLauncherPresenterFactory)
        {
            _sawLauncherPresenterFactory = sawLauncherPresenterFactory ?? 
                                           throw new ArgumentNullException(nameof(sawLauncherPresenterFactory));
        }
        
        public ISawLauncherView Create(
            SawLauncher sawLauncher,
            SawLauncherView sawLauncherView)
        {
            SawLauncherPresenter sawLauncherPresenter =
                _sawLauncherPresenterFactory.Create(sawLauncher, sawLauncherView);
            
            sawLauncherView.Construct(sawLauncherPresenter);
            
            return sawLauncherView;
        }
    }
}
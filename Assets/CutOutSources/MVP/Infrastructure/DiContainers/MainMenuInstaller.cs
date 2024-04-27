using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu;
using Sources.Infrastructure.Factories.Services.FormServices;
using Zenject;

namespace CutOutSources.MVP.Infrastructure.DiContainers
{
    public class MainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFormFactories();
        }
        
        private void BindFormFactories()
        {
            Container.Bind<MVPMainMenuFormServiceFactory>().AsSingle();

            Container.Bind<AuthorizationFormPresenterFactory>().AsSingle();
            Container.Bind<LeaderboardFormPresenterFactory>().AsSingle();
            Container.Bind<MainMenuHudFormViewPresenterFactory>().AsSingle();
            Container.Bind<MainMenuSettingFormPresenterFactory>().AsSingle();
            Container.Bind<NewGameFormPresenterFactory>().AsSingle();
            Container.Bind<WarningNewGameFormPresenterFactory>().AsSingle();
        }
    }
}
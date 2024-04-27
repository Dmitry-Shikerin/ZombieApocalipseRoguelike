using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.Gameplay.Tutorials;
using Sources.Infrastructure.Factories.Services.FormServices;
using Zenject;

namespace CutOutSources.MVP.Infrastructure.DiContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFormFactories();
        }
        
        private void BindFormFactories()
        {
            Container.Bind<MVPGameplayFormServiceFactory>().AsSingle();

            Container.Bind<GameOverFormPresenterFactory>().AsSingle();
            Container.Bind<GameplaySettingsFormPresenterFactory>().AsSingle();
            Container.Bind<HudFormPresenterFactory>().AsSingle();
            Container.Bind<LevelCompletedFormPresenterFactory>().AsSingle();
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
            Container.Bind<GreetingTutorialFormPresenterFactory>().AsSingle();
            Container.Bind<UpgradeFormPresenterFactory>().AsSingle();
        }
    }
}
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Buttons.Handlers;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms;
using Sources.Frameworks.UiFramework.Infrastructure.Commands.Forms.Handlers;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Buttons.Handlers;
using Sources.Frameworks.UiFramework.InfrastructureInterfaces.Commands.Views.Handlers;
using Zenject;

namespace Sources.Infrastructure.DIContainers.MainMenu.UiFramework
{
    public class MainMenuUiFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            // Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            // Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();
            //
            // Container.Bind<UiCollectorFactory>().AsSingle();
            //
            // Container.Bind<UiButtonFactory>().AsSingle();
            // Container.Bind<UiButtonPresenterFactory>().AsSingle();
            //
            // Container.Bind<UiViewFactory>().AsSingle();
            // Container.Bind<UiViewPresenterFactory>().AsSingle();

            //Buttons
            // Container.Bind<IUiButtonService>().To<UiButtonService>().AsSingle();
            Container.Bind<IButtonCommandHandler>().To<MainMenuButtonCommandHandler>().AsSingle();

            Container.Bind<ShowFormCommand>().AsSingle();
            Container.Bind<CompleteTutorialCommand>().AsSingle();
            Container.Bind<LoadMainMenuSceneCommand>().AsSingle();
            Container.Bind<NewGameCommand>().AsSingle();
            Container.Bind<LoadGameCommand>().AsSingle();
            Container.Bind<ShowLeaderboardCommand>().AsSingle();
            Container.Bind<EnableLoadGameButtonCommand>().AsSingle();
            Container.Bind<ClearSavesButtonCommand>().AsSingle();

            //Views
            // Container.Bind<IUiViewService>().To<UiViewService>().AsSingle();
            Container.Bind<IUiViewCommandHandler>().To<MainMenuUiViewCommandHandler>().AsSingle();

            Container.Bind<UnPauseCommand>().AsSingle();
            Container.Bind<PauseCommand>().AsSingle();
            Container.Bind<SaveVolumeCommand>().AsSingle();
            Container.Bind<ClearSavesCommand>().AsSingle();
        }
    }
}
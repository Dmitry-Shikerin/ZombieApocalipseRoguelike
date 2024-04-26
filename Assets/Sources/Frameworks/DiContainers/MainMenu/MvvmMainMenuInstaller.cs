using Sources.Controllers.ModelViews.Forms.MainMenu;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.Presentations.Factories;
using Sources.Frameworks.PresentationInterfaces.Binder;
using Sources.Frameworks.Presentations.Binders;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.YandexSDK;
using Sources.Infrastructure.Factories.Domain.Forms.MainMenu;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.YandexSDK;
using Sources.Infrastructure.Services.UseCases.Commands;
using Sources.Infrastructure.Services.UseCases.Queries;
using Zenject;

namespace Sources.Frameworks.DiContainers.Gameplay
{
    public class MvvmMainMenuInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindFormFactories();
            BindMvvm();
        }

        private void BindMvvm()
        {
            Container.Bind<IBinder>().To<Binder>().AsSingle();
            Container.Bind<IBindableViewFactory>().To<BindableViewFactory>().AsSingle();

            Container.Bind<GetVisibilityQuery>().AsSingle();
            Container.Bind<ShowCommand>().AsSingle();
            Container.Bind<HideCommand>().AsSingle();
        }

        private void BindFormFactories()
        {
            Container.Bind<MVVMMainMenuFormServiceFactory>().AsSingle();
            Container.Bind<LeaderBoardElementPresenterFactory>().AsSingle();
            Container.Bind<LeaderBoardElementViewFactory>().AsSingle();

            Container.Bind<MainMenuHudFormFactory>().AsSingle();
            Container.Bind<MainMenuSettingsFormFactory>().AsSingle();
            Container.Bind<AuthorizationFormFactory>().AsSingle();
            Container.Bind<LeaderboardFormFactory>().AsSingle();
            Container.Bind<NewGameFormFactory>().AsSingle();
            Container.Bind<WarningNewGameFormFactory>().AsSingle();

            Container.Bind<ShowMainMenuHudFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowNewGameFormViewModelComponentFactory>().AsSingle();
            Container.Bind<VisibilityViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowMainMenuSettingsFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowLeaderboardFormViewModelComponentFactory>().AsSingle();
            Container.Bind<LoadGameViewModelComponentFactory>().AsSingle();
            Container.Bind<TryShowNewGameFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowWarningNewGameFormViewModelComponentFactory>().AsSingle();

            Container
                .Bind<IViewModelFactory<MainMenuHudFormViewModel, MainMenuHudForm>>()
                .To<MainMenuHudFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<MainMenuSettingsFormViewModel, MainMenuSettingsForm>>()
                .To<MainMenuSettingsFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<AuthorizationFormViewModel, AuthorizationForm>>()
                .To<AuthorizationFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<LeaderboardFormViewModel, LeaderboardForm>>()
                .To<LeaderboardFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<NewGameFormViewModel, NewGameForm>>()
                .To<NewGameFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<WarningNewGameFormViewModel, WarningNewGameForm>>()
                .To<WarningNewGameFormViewModelFactory>()
                .AsSingle();

            Container
                .Bind<IBindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm>>()
                .To<BindableViewBuilder<MainMenuHudFormViewModel, MainMenuHudForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm>>()
                .To<BindableViewBuilder<MainMenuSettingsFormViewModel, MainMenuSettingsForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm>>()
                .To<BindableViewBuilder<AuthorizationFormViewModel, AuthorizationForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm>>()
                .To<BindableViewBuilder<LeaderboardFormViewModel, LeaderboardForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<NewGameFormViewModel, NewGameForm>>()
                .To<BindableViewBuilder<NewGameFormViewModel, NewGameForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<WarningNewGameFormViewModel, WarningNewGameForm>>()
                .To<BindableViewBuilder<WarningNewGameFormViewModel, WarningNewGameForm>>()
                .AsSingle();
        }
    }
}
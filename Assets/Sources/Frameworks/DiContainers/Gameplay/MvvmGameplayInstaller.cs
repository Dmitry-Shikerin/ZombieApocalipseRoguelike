using Sources.Controllers.ModelViews.Forms.Gameplay;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.Frameworks.MVVM.Infrastructure.Builders;
using Sources.Frameworks.MVVM.InfrastructureInterfaces;
using Sources.Frameworks.MVVM.PresentationInterfaces.Factories;
using Sources.Frameworks.MVVM.Presentations.Factories;
using Sources.Frameworks.PresentationInterfaces.Binder;
using Sources.Frameworks.Presentations.Binders;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Components;
using Sources.Infrastructure.Factories.Controllers.ViewModels.Forms.Gameplay;
using Sources.Infrastructure.Factories.Domain.Forms.Gameplay;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Services.UseCases.Commands;
using Sources.Infrastructure.Services.UseCases.Queries;
using Zenject;

namespace Sources.Frameworks.DiContainers.Gameplay
{
    public class MvvmGameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMvvm();
            BindFormFactories();
        }

        private void BindFormFactories()
        {
            Container.Bind<MVVMGameplayFormServiceFactory>().AsSingle();
            Container.Bind<GameOverFormFactory>().AsSingle();
            Container.Bind<LevelCompletedFormFactory>().AsSingle();
            Container.Bind<UpgradeFormFactory>().AsSingle();
            Container.Bind<TutorialFormFactory>().AsSingle();
            Container.Bind<GameplaySettingFormFactory>().AsSingle();
            Container.Bind<GameplayHudFormFactory>().AsSingle();
            Container.Bind<PauseFormFactory>().AsSingle();

            Container.Bind<VisibilityViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowPauseFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowGameplayHudFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowGameplaySettingsFormViewModelComponentFactory>().AsSingle();
            Container.Bind<ShowUpgradeFormViewModelComponentFactory>().AsSingle();
            Container.Bind<LoadMainMenuViewModelComponentFactory>().AsSingle();

            Container
                .Bind<IViewModelFactory<GameplayHudFormViewModel, GameplayHudForm>>()
                .To<GameplayHudFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<PauseFormViewModel, PauseForm>>()
                .To<PauseFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<GameplaySettingsFormViewModel, GameplaySettingsForm>>()
                .To<GameplaySettingsFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<UpgradeFormViewModel, UpgradeForm>>()
                .To<UpgradeFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<GameOverFormViewModel, GameOverForm>>()
                .To<GameOverFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<LevelCompletedFormViewModel, LevelCompletedForm>>()
                .To<LevelCompletedFormViewModelFactory>()
                .AsSingle();
            Container
                .Bind<IViewModelFactory<TutorialFormViewModel, TutorialForm>>()
                .To<TutorialFormViewModelFactory>()
                .AsSingle();

            Container
                .Bind<IBindableViewBuilder<PauseFormViewModel, PauseForm>>()
                .To<BindableViewBuilder<PauseFormViewModel, PauseForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<GameplayHudFormViewModel, GameplayHudForm>>()
                .To<BindableViewBuilder<GameplayHudFormViewModel, GameplayHudForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<GameplaySettingsFormViewModel, GameplaySettingsForm>>()
                .To<BindableViewBuilder<GameplaySettingsFormViewModel, GameplaySettingsForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<UpgradeFormViewModel, UpgradeForm>>()
                .To<BindableViewBuilder<UpgradeFormViewModel, UpgradeForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<GameOverFormViewModel, GameOverForm>>()
                .To<BindableViewBuilder<GameOverFormViewModel, GameOverForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<LevelCompletedFormViewModel, LevelCompletedForm>>()
                .To<BindableViewBuilder<LevelCompletedFormViewModel, LevelCompletedForm>>()
                .AsSingle();
            Container
                .Bind<IBindableViewBuilder<TutorialFormViewModel, TutorialForm>>()
                .To<BindableViewBuilder<TutorialFormViewModel, TutorialForm>>()
                .AsSingle();
        }

        private void BindMvvm()
        {
            Container.Bind<IBinder>().To<Binder>().AsSingle();
            Container.Bind<IBindableViewFactory>().To<BindableViewFactory>().AsSingle();

            Container.Bind<GetVisibilityQuery>().AsSingle();
            Container.Bind<ShowCommand>().AsSingle();
            Container.Bind<HideCommand>().AsSingle();
        }
    }
}
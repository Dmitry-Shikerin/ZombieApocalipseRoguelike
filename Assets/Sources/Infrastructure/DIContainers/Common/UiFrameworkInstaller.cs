using Sources.Frameworks.UiFramework.Infrastructure.Factories.Controllers.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Controllers.Views;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Collectors;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Buttons;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Views.Forms;
using Sources.Frameworks.UiFramework.Services.AudioSources;
using Sources.Frameworks.UiFramework.Services.Buttons;
using Sources.Frameworks.UiFramework.Services.Forms;
using Sources.Frameworks.UiFramework.Services.Localizations;
using Sources.Frameworks.UiFramework.Services.Views;
using Sources.Frameworks.UiFramework.ServicesInterfaces.AudioSources;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Buttons;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Views;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Common
{
    public class UiFrameworkInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<IAudioService>().To<AudioService>().AsSingle();
            Container.Bind<ILocalizationService>().To<LocalizationService>().AsSingle();

            Container.Bind<UiCollectorFactory>().AsSingle();

            Container.Bind<UiButtonFactory>().AsSingle();
            Container.Bind<UiButtonPresenterFactory>().AsSingle();

            Container.Bind<UiViewFactory>().AsSingle();
            Container.Bind<UiViewPresenterFactory>().AsSingle();
            
            Container.Bind<IUiButtonService>().To<UiButtonService>().AsSingle();
            
            Container.Bind<IUiViewService>().To<UiViewService>().AsSingle();
        }
    }
}
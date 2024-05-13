using Sources.Frameworks.YandexSdcFramework.Services.AdvertisingServices;
using Sources.Frameworks.YandexSdcFramework.Services.Focuses;
using Sources.Frameworks.YandexSdcFramework.Services.Leaderboards;
using Sources.Frameworks.YandexSdcFramework.Services.PlayerAccounts;
using Sources.Frameworks.YandexSdcFramework.Services.SdcInitializeServices;
using Sources.Frameworks.YandexSdcFramework.Services.Stickies;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Focuses;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.Leaderboads;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.PlayerAccounts;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.SdcInitializeServices;
using Sources.InfrastructureInterfaces.Services.YandexSDKServices;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class GameplaySdcServicesInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<AdvertisingService>().AsSingle();
            Container.Bind<IFocusService>().To<FocusService>().AsSingle();
            Container.Bind<ILeaderboardInitializeService>().To<YandexLeaderboardInitializeService>().AsSingle();
            Container.Bind<ILeaderBoardScoreSetter>().To<YandexLeaderBoardScoreSetter>().AsSingle();
            Container.Bind<IPlayerAccountAuthorizeService>().To<PlayerAccountAuthorizeService>().AsSingle();
            Container.Bind<ISdcInitializeService>().To<SdcInitializeService>().AsSingle();
            Container.Bind<IStickyService>().To<StickyService>().AsSingle();
        }
    }
}
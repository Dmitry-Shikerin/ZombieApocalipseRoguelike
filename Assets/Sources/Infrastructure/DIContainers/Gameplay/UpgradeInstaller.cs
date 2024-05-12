using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Upgrades.Configs.Containers;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Upgrades;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Upgrades;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Utils.CustomCollections;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class UpgradeInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<UpgradeConfigContainer>()
                .FromResource("Configs/Upgrades/Containers/UpgradeConfigContainer")
                .AsSingle();
            
            Container.Bind<IUpgradeConfigCollectionService>().To<UpgradeConfigCollectionService>().AsSingle();
            
            Container.BindInterfacesAndSelfTo<CustomCollection<Upgrader>>().AsSingle();
            Container.Bind<IUpgradeService>().To<UpgradeService>().AsSingle();
            
            Container.Bind<UpgradePresenterFactory>().AsSingle();
            Container.Bind<UpgradeViewFactory>().AsSingle();

            Container.Bind<UpgradeUiPresenterFactory>().AsSingle();
            Container.Bind<UpgradeUiFactory>().AsSingle();

            Container.Bind<UpgradeDescriptionPresenterFactory>().AsSingle();
            Container.Bind<UpgradeDescriptionViewFactory>().AsSingle();
        }
    }
}
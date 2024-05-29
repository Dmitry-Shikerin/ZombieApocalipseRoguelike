using Sources.Infrastructure.Factories.Views.FirstAidKitViewFactory;
using Sources.Infrastructure.Factories.Views.RewardItems;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.Infrastructure.Services.Spawners;
using Sources.InfrastructureInterfaces.Factories.Views.FirstAidKits;
using Sources.InfrastructureInterfaces.Factories.Views.RewardItems;
using Sources.InfrastructureInterfaces.Services.ObjectPools.Generic;
using Sources.InfrastructureInterfaces.Services.Spawners;
using Sources.Presentations.Views.FirstAidKits;
using Sources.Presentations.Views.RewardItems;
using Zenject;

namespace Sources.Infrastructure.DIContainers.Gameplay
{
    public class ItemsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectPool<FirstAidKitView>>().To<ObjectPool<FirstAidKitView>>().AsSingle();
            Container.Bind<IObjectPool<RewardItemView>>().To<ObjectPool<RewardItemView>>().AsSingle();

            Container.Bind<IFirstAidKitSpawnService>().To<FirstAidKitSpawnService>().AsSingle();
            Container.Bind<IRewardItemSpawnService>().To<RewardItemSpawnService>().AsSingle();

            Container.Bind<IFirstAidKitViewFactory>().To<FirstAidKitViewFactory>().AsSingle();
            Container.Bind<IRewardItemViewFactory>().To<RewardItemViewFactory>().AsSingle();
        }
    }
}
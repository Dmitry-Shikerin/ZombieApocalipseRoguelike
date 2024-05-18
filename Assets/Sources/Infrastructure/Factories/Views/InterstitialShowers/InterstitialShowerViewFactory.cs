using System;
using JetBrains.Annotations;
using Sources.Controllers.Presenters.InterstitialShowers;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Presenters.InterstitialShowers;
using Sources.Presentations.Views.InterstitialShowers;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;

namespace Sources.Infrastructure.Factories.Views.InterstitialShowers
{
    public class InterstitialShowerViewFactory
    {
        private readonly InterstitialShowerPresenterFactory _presenterFactory;

        public InterstitialShowerViewFactory(InterstitialShowerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IInterstitialShowerView Create(
            IEnemySpawner enemySpawner, IUpgradeController upgradeController, InterstitialShowerView view)
        {
            InterstitialShowerPresenter presenter = _presenterFactory.Create(
                enemySpawner, upgradeController, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}
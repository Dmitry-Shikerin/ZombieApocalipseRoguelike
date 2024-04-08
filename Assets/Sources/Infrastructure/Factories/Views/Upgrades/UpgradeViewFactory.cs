using System;
using Sources.Controllers.Upgrades;
using Sources.Domain.Players;
using Sources.Domain.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Views.Upgrades
{
    public class UpgradeViewFactory
    {
        private readonly UpgradePresenterFactory _upgradePresenterFactory;

        public UpgradeViewFactory(UpgradePresenterFactory upgradePresenterFactory)
        {
            _upgradePresenterFactory = upgradePresenterFactory ?? 
                                       throw new ArgumentNullException(nameof(upgradePresenterFactory));
        }

        public IUpgradeView Create(Upgrader upgrader, PlayerWallet playerWallet, UpgradeView upgradeView)
        {
            UpgradePresenter upgradePresenter = 
                _upgradePresenterFactory.Create(upgrader, playerWallet, upgradeView);
            
            upgradeView.Construct(upgradePresenter);
            
            return upgradeView;
        }
    }
}
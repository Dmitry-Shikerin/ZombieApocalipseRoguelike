using System;
using Sources.Controllers.Presenters.Upgrades;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Views.Upgrades
{
    public class UpgradeViewFactory : IUpgradeViewFactory
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
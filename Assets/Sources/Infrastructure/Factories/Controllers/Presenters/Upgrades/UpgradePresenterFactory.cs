using Sources.Controllers.Presenters.Upgrades;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades
{
    public class UpgradePresenterFactory
    {
        public UpgradePresenter Create(Upgrader upgrader, PlayerWallet playerWallet, IUpgradeView upgradeView) =>
            new(upgrader, playerWallet, upgradeView);
    }
}
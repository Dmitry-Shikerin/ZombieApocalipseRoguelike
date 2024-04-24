using Sources.Controllers.Upgrades;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Upgrades
{
    public class UpgradePresenterFactory
    {
        public UpgradePresenter Create(Upgrader upgrader, PlayerWallet playerWallet, IUpgradeView upgradeView)
        {
            return new UpgradePresenter(upgrader, playerWallet, upgradeView);
        }
    }
}
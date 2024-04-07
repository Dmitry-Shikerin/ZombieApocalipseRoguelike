using Sources.Controllers.Upgrades;
using Sources.Domain.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Upgrades
{
    public class UpgradePresenterFactory
    {
        public UpgradePresenter Create(Upgrader upgrader, IUpgradeView upgradeView)
        {
            return new UpgradePresenter(upgrader, upgradeView);
        }
    }
}
using Sources.Controllers.Upgrades;
using Sources.DomainInterfaces.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Upgrades
{
    public class UpgradeUiPresenterFactory
    {
        public UpgradeUiPresenter Create(IUpgrader upgrader,  IUpgradeUi upgradeUi)
        {
            return new UpgradeUiPresenter(upgrader, upgradeUi);
        }
    }
}
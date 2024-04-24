using Sources.Controllers.Upgrades.Controllers;
using Sources.Domain.Models.Upgrades.Controllers;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;

namespace Sources.Infrastructure.Factories.Controllers.Upgrades.Controllers
{
    public class UpgradeControllerPresenterFactory
    {
        public UpgradeControllerPresenter Create(
            UpgradeController upgradeController,
            IUpgradeControllerView upgradeControllerView)
        {
            return new UpgradeControllerPresenter(upgradeController, upgradeControllerView);
        }
    }
}
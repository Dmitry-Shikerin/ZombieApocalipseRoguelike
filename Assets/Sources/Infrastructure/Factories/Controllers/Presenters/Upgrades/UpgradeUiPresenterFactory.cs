using System;
using Sources.Controllers.Upgrades;
using Sources.DomainInterfaces.Upgrades;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades
{
    public class UpgradeUiPresenterFactory
    {
        private readonly IUpgradeConfigCollectionService _upgradeConfigCollectionService;

        public UpgradeUiPresenterFactory(IUpgradeConfigCollectionService upgradeConfigCollectionService)
        {
            _upgradeConfigCollectionService = upgradeConfigCollectionService ?? 
                                       throw new ArgumentNullException(nameof(upgradeConfigCollectionService));
        }

        public UpgradeUiPresenter Create(IUpgrader upgrader,  IUpgradeUi upgradeUi)
        {
            return new UpgradeUiPresenter(upgrader, upgradeUi, _upgradeConfigCollectionService);
        }
    }
}
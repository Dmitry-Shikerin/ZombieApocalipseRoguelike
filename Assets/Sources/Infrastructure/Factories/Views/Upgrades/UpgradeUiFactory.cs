using System;
using Sources.Controllers.Upgrades;
using Sources.DomainInterfaces.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Views.Upgrades
{
    public class UpgradeUiFactory
    {
        private readonly UpgradeUiPresenterFactory _upgradeUiPresenterFactory;

        public UpgradeUiFactory(UpgradeUiPresenterFactory upgradeUiPresenterFactory)
        {
            _upgradeUiPresenterFactory = upgradeUiPresenterFactory ??
                                         throw new ArgumentNullException(nameof(upgradeUiPresenterFactory));
        }

        public IUpgradeUi Create(IUpgrader upgrader, UpgradeUi upgradeUi)
        {
            UpgradeUiPresenter upgradeUiPresenter = _upgradeUiPresenterFactory.Create(upgrader, upgradeUi);
            
            upgradeUi.Construct(upgradeUiPresenter);
            
            return upgradeUi;
        }
    }
}
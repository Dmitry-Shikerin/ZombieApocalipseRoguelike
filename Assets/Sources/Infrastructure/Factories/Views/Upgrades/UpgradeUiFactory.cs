using System;
using Sources.Controllers.Presenters.Upgrades;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Views.Upgrades
{
    public class UpgradeUiFactory : IUpgradeUiFactory
    {
        private readonly UpgradeUiPresenterFactory _presenterFactory;

        public UpgradeUiFactory(UpgradeUiPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ??
                                         throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IUpgradeUi Create(IUpgrader upgrader, UpgradeUi upgradeUi)
        {
            UpgradeUiPresenter upgradeUiPresenter = _presenterFactory.Create(upgrader, upgradeUi);

            upgradeUi.Construct(upgradeUiPresenter);

            return upgradeUi;
        }
    }
}
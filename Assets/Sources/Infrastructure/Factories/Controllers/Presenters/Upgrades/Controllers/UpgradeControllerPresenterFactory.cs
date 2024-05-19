using System;
using Sources.Controllers.Presenters.Upgrades.Controllers;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Upgrades.Controllers;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades.Controllers
{
    public class UpgradeControllerPresenterFactory
    {
        private readonly ICustomCollection<Upgrader> _upgradersCollection;
        private readonly IUpgradeViewFactory _upgradeViewFactory;
        private readonly IUpgradeUiFactory _upgradeUiFactory;
        private readonly IUpgradeDescriptionViewFactory _upgradeDescriptionViewFactory;
        private readonly IFormService _formService;
        private readonly IUpgradeService _upgradeService;

        public UpgradeControllerPresenterFactory(
            ICustomCollection<Upgrader> upgradersCollection,
            IUpgradeViewFactory upgradeViewFactory,
            IUpgradeUiFactory upgradeUiFactory,
            IUpgradeDescriptionViewFactory upgradeDescriptionViewFactory,
            IFormService formService,
            IUpgradeService upgradeService)
        {
            _upgradersCollection = upgradersCollection ?? 
                                   throw new ArgumentNullException(nameof(upgradersCollection));
            _upgradeViewFactory = upgradeViewFactory ?? 
                                  throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _upgradeDescriptionViewFactory = upgradeDescriptionViewFactory 
                                             ?? throw new ArgumentNullException(nameof(upgradeDescriptionViewFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }

        public UpgradeControllerPresenter Create(
            UpgradeController upgradeController,
            PlayerWallet playerWallet,
            IUpgradeControllerView upgradeControllerView)
        {
            return new UpgradeControllerPresenter(
                upgradeController,
                playerWallet, 
                upgradeControllerView,
                _upgradersCollection,
                _upgradeViewFactory,
                _upgradeUiFactory,
                _upgradeDescriptionViewFactory,
                _formService,
                _upgradeService);
        }
    }
}
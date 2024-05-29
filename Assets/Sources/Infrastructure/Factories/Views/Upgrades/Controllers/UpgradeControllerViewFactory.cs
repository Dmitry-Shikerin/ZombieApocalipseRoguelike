using System;
using Sources.Controllers.Presenters.Upgrades.Controllers;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades.Controllers;
using Sources.DomainInterfaces.Models.Characters;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades.Controllers;
using Sources.Presentations.Views.Upgrades.Controllers;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;

namespace Sources.Infrastructure.Factories.Views.Upgrades.Controllers
{
    public class UpgradeControllerViewFactory
    {
        private readonly UpgradeControllerPresenterFactory _presenterFactory;

        public UpgradeControllerViewFactory(UpgradeControllerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IUpgradeControllerView Create(
            UpgradeController upgradeController,
            ICharacterHealth characterHealth,
            PlayerWallet playerWallet,
            UpgradeControllerView upgradeControllerView)
        {
            UpgradeControllerPresenter presenter = _presenterFactory.Create(
                upgradeController, characterHealth, playerWallet, upgradeControllerView);
            upgradeControllerView.Construct(presenter);

            return upgradeControllerView;
        }
    }
}
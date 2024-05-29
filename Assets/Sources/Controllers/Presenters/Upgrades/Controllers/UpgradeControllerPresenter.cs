using System;
using System.Collections.Generic;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Upgrades.Controllers;
using Sources.DomainInterfaces.Models.Characters;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;
using Sources.Utils.CustomCollections;

namespace Sources.Controllers.Presenters.Upgrades.Controllers
{
    public class UpgradeControllerPresenter : PresenterBase
    {
        private readonly UpgradeController _upgradeController;
        private readonly ICharacterHealth _characterHealth;
        private readonly PlayerWallet _playerWallet;
        private readonly IUpgradeControllerView _upgradeControllerView;
        private readonly ICustomCollection<Upgrader> _upgradeCollection;
        private readonly IUpgradeViewFactory _upgradeViewFactory;
        private readonly IUpgradeUiFactory _upgradeUiFactory;
        private readonly IUpgradeDescriptionViewFactory _upgradeDescriptionViewFactory;
        private readonly IFormService _formService;
        private readonly IUpgradeService _upgradeService;

        public UpgradeControllerPresenter(
            UpgradeController upgradeController,
            ICharacterHealth characterHealth,
            PlayerWallet playerWallet,
            IUpgradeControllerView upgradeControllerView,
            ICustomCollection<Upgrader> upgradeCollection,
            IUpgradeViewFactory upgradeViewFactory,
            IUpgradeUiFactory upgradeUiFactory,
            IUpgradeDescriptionViewFactory upgradeDescriptionViewFactory,
            IFormService formService,
            IUpgradeService upgradeService)
        {
            _upgradeController = upgradeController ?? throw new ArgumentNullException(nameof(upgradeController));
            _characterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _upgradeControllerView = upgradeControllerView ??
                                     throw new ArgumentNullException(nameof(upgradeControllerView));
            _upgradeCollection = upgradeCollection ?? throw new ArgumentNullException(nameof(upgradeCollection));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _upgradeDescriptionViewFactory = upgradeDescriptionViewFactory ??
                                             throw new ArgumentNullException(nameof(upgradeDescriptionViewFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }

        public override void Enable()
        {
            OnUpgradeFormChanged();
            _playerWallet.CoinsChanged += OnUpgradeFormChanged;
        }

        public override void Disable() =>
            _playerWallet.CoinsChanged -= OnUpgradeFormChanged;

        private void OnUpgradeFormChanged()
        {
            try
            {
                if (_characterHealth.IsDied)
                    return;

                if (_formService.IsActive(FormId.Upgrade))
                    return;

                IReadOnlyList<Upgrader> availableUpgraders = _upgradeService.GetAvailableUpgrades(
                    _playerWallet, _upgradeCollection);
                int upgradersCount = _upgradeService.GetUpgradesCount(availableUpgraders.Count, _upgradeCollection);
                CreateFactories(availableUpgraders, upgradersCount);
                _formService.Show(FormId.Upgrade);
                _upgradeController.ShowUpgradeForm();
            }
            catch (IndexOutOfRangeException)
            {
            }
        }

        private void CreateFactories(IReadOnlyList<Upgrader> availableUpgraders, int count)
        {
            for (int i = 0; i < count; i++)
            {
                _upgradeUiFactory.Create(availableUpgraders[i], _upgradeControllerView.UpgradeUis[i]);
                _upgradeViewFactory.Create(
                    availableUpgraders[i], _playerWallet, _upgradeControllerView.UpgradeViews[i]);
                _upgradeDescriptionViewFactory.Create(
                    availableUpgraders[i], _upgradeControllerView.UpgradeDescriptionViews[i]);
            }
        }
    }
}
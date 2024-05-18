using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Controllers.Common;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Domain.Models.Upgrades.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades.Controllers;
using Sources.Utils.CustomCollections;

namespace Sources.Controllers.Presenters.Upgrades.Controllers
{
    public class UpgradeControllerPresenter : PresenterBase
    {
        private readonly UpgradeController _upgradeController;
        private readonly PlayerWallet _playerWallet;
        private readonly IUpgradeControllerView _upgradeControllerView;
        private readonly ICustomCollection<Upgrader> _upgradeCollection;
        private readonly IUpgradeViewFactory _upgradeViewFactory;
        private readonly IUpgradeUiFactory _upgradeUiFactory;
        private readonly IUpgradeDescriptionViewFactory _upgradeDescriptionViewFactory;
        private readonly IFormService _formService;

        public UpgradeControllerPresenter(
            UpgradeController upgradeController, 
            PlayerWallet playerWallet,
            IUpgradeControllerView upgradeControllerView,
            ICustomCollection<Upgrader> upgradeCollection,
            IUpgradeViewFactory upgradeViewFactory,
            IUpgradeUiFactory upgradeUiFactory,
            IUpgradeDescriptionViewFactory upgradeDescriptionViewFactory,
            IFormService formService)
        {
            _upgradeController = upgradeController ?? throw new ArgumentNullException(nameof(upgradeController));
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _upgradeControllerView = upgradeControllerView ?? 
                                     throw new ArgumentNullException(nameof(upgradeControllerView));
            _upgradeCollection = upgradeCollection ?? throw new ArgumentNullException(nameof(upgradeCollection));
            _upgradeViewFactory = upgradeViewFactory ?? throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? throw new ArgumentNullException(nameof(upgradeUiFactory));
            _upgradeDescriptionViewFactory = upgradeDescriptionViewFactory ?? 
                                             throw new ArgumentNullException(nameof(upgradeDescriptionViewFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public override void Enable()
        {
            OnUpgradeFormChanged();
            _playerWallet.CoinsChanged += OnUpgradeFormChanged;
        }

        public override void Disable()
        {
            _playerWallet.CoinsChanged -= OnUpgradeFormChanged;
        }

        private void OnUpgradeFormChanged()
        {
            try
            {
                if (_formService.IsActive(FormId.Upgrade))
                    return;

                List<Upgrader> availableUpgraders = GetAvailableUpgraders();
                int upgradersCount = GetUpgradersCount(availableUpgraders);
                CreateFactories(availableUpgraders, upgradersCount);
                _formService.Show(FormId.Upgrade);
                _upgradeController.ShowUpgradeForm();
            }
            catch (IndexOutOfRangeException)
            {
            }
        }
        
        //TODO вынести эти 2 метода в сервис
        private int GetUpgradersCount(List<Upgrader> availableUpgraders)
        {
            if (availableUpgraders.Count >= 3)
                return 3;
            
            if (availableUpgraders.Count is < 3 and > 0)
                return availableUpgraders.Count;

            throw new IndexOutOfRangeException();
        }
        
        private List<Upgrader> GetAvailableUpgraders()
        {
            List<Upgrader> availableUpgraders = new List<Upgrader>();

            foreach (Upgrader upgrader in _upgradeCollection)
            {
                if(upgrader.CurrentLevel == 3)
                    continue;
                
                if(upgrader.MoneyPerUpgrades[upgrader.CurrentLevel] <= _playerWallet.Coins)
                    availableUpgraders.Add(upgrader);
            }

            return availableUpgraders.OrderBy(upgrader => upgrader.CurrentLevel).ToList();
        }

        private void CreateFactories(List<Upgrader> availableUpgraders, int count)
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
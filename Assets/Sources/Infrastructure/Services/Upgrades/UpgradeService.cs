using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Upgrades;
using Sources.Utils.CustomCollections;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeService : IUpgradeService
    {
        private readonly ICustomCollection<Upgrader> _upgradeCollection;
        private readonly GameplayHud _gameplayHud;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly IFormService _formService;
        private readonly UpgradeDescriptionViewFactory _upgradeDescriptionViewFactory;
        private readonly IReadOnlyList<UpgradeUi> _upgradeUis;
        private readonly IReadOnlyList<UpgradeView> _upgradeViews;

        private PlayerWallet _playerWallet;
        private int _numberOfFilledAbilities;

        public UpgradeService(
            ICustomCollection<Upgrader> upgradeCollection,
            GameplayHud gameplayHud,
            UpgradeViewFactory upgradeViewFactory,
            UpgradeUiFactory upgradeUiFactory,
            IFormService formService,
            UpgradeDescriptionViewFactory upgradeDescriptionViewFactory)
        {
            _upgradeCollection = upgradeCollection ?? 
                                        throw new ArgumentNullException(nameof(upgradeCollection));
            _gameplayHud = gameplayHud ?? throw new ArgumentNullException(nameof(gameplayHud));
            _upgradeViewFactory = upgradeViewFactory ?? 
                                  throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? 
                                throw new ArgumentNullException(nameof(upgradeUiFactory));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _upgradeDescriptionViewFactory = upgradeDescriptionViewFactory ?? 
                                             throw new ArgumentNullException(nameof(upgradeDescriptionViewFactory));
            _upgradeUis = gameplayHud.UpgradeUis ?? 
                          throw new NullReferenceException(nameof(gameplayHud.UpgradeUis));
            _upgradeViews = gameplayHud.UpgradeViews ?? 
                          throw new NullReferenceException(nameof(gameplayHud.UpgradeUis));
        }

        public event Action UpgradeFormShowed;

        //TODO это должен быть контроллер?

        public void Construct(PlayerWallet playerWallet)
        {
            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
        }

        public void Enable()
        {
            OnUpgradeFormChanged();
            _playerWallet.CoinsChanged += OnUpgradeFormChanged;
        }

        public void Disable()
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
                UpgradeFormShowed?.Invoke();
            }
            catch (IndexOutOfRangeException)
            {
            }
        }
        
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
                _upgradeUiFactory.Create(availableUpgraders[i], _upgradeUis[i]);
                _upgradeViewFactory.Create(availableUpgraders[i], _playerWallet, _upgradeViews[i]);
                _upgradeDescriptionViewFactory.Create(availableUpgraders[i], _gameplayHud.UpgradeDescriptionViews[i]);
            }
        }
    }
}
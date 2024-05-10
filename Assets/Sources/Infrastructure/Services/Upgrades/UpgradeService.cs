using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Providers;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Upgrades;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeService : IUpgradeService
    {
        private PlayerWallet _playerWallet;
        private readonly PlayerWalletProvider _playerWalletProvider;
        private readonly ICustomList<Upgrader> _upgradeCollection;
        private readonly GameplayHud _gameplayHud;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly IFormService _formService;
        private readonly UpgradeDescriptionViewFactory _upgradeDescriptionViewFactory;
        private readonly IReadOnlyList<UpgradeUi> _upgradeUis;
        private readonly IReadOnlyList<UpgradeView> _upgradeViews;

        private int numberOfFilledAbilities;

        public UpgradeService(
            PlayerWalletProvider playerWalletProvider,
            ICustomList<Upgrader> upgradeCollection,
            GameplayHud gameplayHud,
            UpgradeViewFactory upgradeViewFactory,
            UpgradeUiFactory upgradeUiFactory,
            IFormService formService,
            UpgradeDescriptionViewFactory upgradeDescriptionViewFactory)
        {
            if (gameplayHud == null) throw new ArgumentNullException(nameof(gameplayHud));
            if (gameplayHud == null) 
                throw new ArgumentNullException(nameof(gameplayHud));

            _playerWalletProvider = playerWalletProvider ?? 
                                    throw new ArgumentNullException(nameof(playerWalletProvider));
            _upgradeCollection = upgradeCollection ?? 
                                        throw new ArgumentNullException(nameof(upgradeCollection));
            _gameplayHud = gameplayHud;
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

        private PlayerWallet PlayerWallet => _playerWallet ??= _playerWalletProvider.PlayerWallet;

        //TODO это должен быть контроллер?
        public void Enable()
        {
            OnUpgradeFormChanged();
            PlayerWallet.CoinsChanged += OnUpgradeFormChanged;
        }

        public void Disable()
        {
            PlayerWallet.CoinsChanged -= OnUpgradeFormChanged;
        }

        private void OnUpgradeFormChanged()
        {
            if(_formService.IsActive(FormId.Upgrade))
                return;
            
            //TODO сделать провайдер коллекций от Т и использовать его вместо создания отдельных классов для коллекций
            //TODO сделать у этого класса индексатор
            List<Upgrader> availableUpgraders = new List<Upgrader>();

            foreach (Upgrader upgrader in _upgradeCollection)
            {
                if(upgrader.CurrentLevel == 3)
                    continue;
                
                if(upgrader.MoneyPerUpgrades[upgrader.CurrentLevel] <= PlayerWallet.Coins)
                    availableUpgraders.Add(upgrader);
            }

            availableUpgraders = availableUpgraders.OrderBy(upgrader => upgrader.CurrentLevel).ToList();
            
            //TODO фига себе запись
            if (availableUpgraders.Count >= 3)
                numberOfFilledAbilities = 3;
            else if (availableUpgraders.Count is < 3 and > 0)
                numberOfFilledAbilities = availableUpgraders.Count;
            else
                return;
            
            for (int i = 0; i < numberOfFilledAbilities; i++)
            {
                _upgradeUiFactory.Create(availableUpgraders[i], _upgradeUis[i]);
                _upgradeViewFactory.Create(availableUpgraders[i], PlayerWallet, _upgradeViews[i]);
                _upgradeDescriptionViewFactory.Create(availableUpgraders[i], _gameplayHud.UpgradeDescriptionViews[i]);
            }
                
            _formService.Show(FormId.Upgrade);
        }
    }
}
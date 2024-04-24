using System;
using System.Collections.Generic;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Upgrades;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.Infrastructure.Services.Providers;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Upgrades;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeService : IUpgradeService
    {
        private PlayerWallet _playerWallet;
        private readonly PlayerWalletProvider _playerWalletProvider;
        private readonly IUpgradeCollectionService _upgradeCollectionService;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly IReadOnlyList<UpgradeUi> _upgradeUis;
        private readonly IReadOnlyList<UpgradeView> _upgradeViews;

        public UpgradeService(
            PlayerWalletProvider playerWalletProvider,
            IUpgradeCollectionService upgradeCollectionService,
            GameplayHud gameplayHud,
            UpgradeViewFactory upgradeViewFactory,
            UpgradeUiFactory upgradeUiFactory)
        {
            if (gameplayHud == null) 
                throw new ArgumentNullException(nameof(gameplayHud));

            _playerWalletProvider = playerWalletProvider ?? 
                                    throw new ArgumentNullException(nameof(playerWalletProvider));
            _upgradeCollectionService = upgradeCollectionService ?? 
                                        throw new ArgumentNullException(nameof(upgradeCollectionService));
            _upgradeViewFactory = upgradeViewFactory ?? 
                                  throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? 
                                throw new ArgumentNullException(nameof(upgradeUiFactory));
            _upgradeUis = gameplayHud.UpgradeUis ?? 
                          throw new NullReferenceException(nameof(gameplayHud.UpgradeUis));
            _upgradeViews = gameplayHud.UpgradeViews ?? 
                          throw new NullReferenceException(nameof(gameplayHud.UpgradeUis));
        }

        private PlayerWallet PlayerWallet => _playerWallet ??= _playerWalletProvider.PlayerWallet;

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
            IReadOnlyList<Upgrader> upgraders = _upgradeCollectionService.Get();
            List<Upgrader> awaiableUpgraders = new List<Upgrader>();

            foreach (Upgrader upgrader in upgraders)
            {
                if(upgrader.CurrentLevel == 3)
                    continue;
                
                if(upgrader.MoneyPerUpgrades[upgrader.CurrentLevel] <= PlayerWallet.Coins)
                    awaiableUpgraders.Add(upgrader);
            }

            if (awaiableUpgraders.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    _upgradeUiFactory.Create(awaiableUpgraders[i], _upgradeUis[i]);
                    _upgradeViewFactory.Create(awaiableUpgraders[i], PlayerWallet, _upgradeViews[i]);
                }
                
                // _viewFormService.Show<UpgradeFormView>();
            }
        }
    }
}
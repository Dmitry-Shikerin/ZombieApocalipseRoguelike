using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Players;
using Sources.Domain.Upgrades;
using Sources.Infrastructure.Factories.Views.Upgrades;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Forms.Gameplay;
using Sources.Presentations.Views.Upgrades;

namespace Sources.Infrastructure.Services.Upgrades
{
    public class UpgradeService : IUpgradeService
    {
        private readonly PlayerWallet _playerWallet;
        private readonly IUpgradeCollectionService _upgradeCollectionService;
        private readonly UpgradeViewFactory _upgradeViewFactory;
        private readonly UpgradeUiFactory _upgradeUiFactory;
        private readonly IFormService _formService;
        private readonly IReadOnlyList<UpgradeUi> _upgradeUis;
        private readonly IReadOnlyList<UpgradeView> _upgradeViews;

        public UpgradeService(
            PlayerWallet playerWallet,
            IUpgradeCollectionService upgradeCollectionService,
            GameplayHud gameplayHud,
            UpgradeViewFactory upgradeViewFactory,
            UpgradeUiFactory upgradeUiFactory,
            IFormService formService)
        {
            if (gameplayHud == null) 
                throw new ArgumentNullException(nameof(gameplayHud));

            _playerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            _upgradeCollectionService = upgradeCollectionService ?? 
                                        throw new ArgumentNullException(nameof(upgradeCollectionService));
            _upgradeViewFactory = upgradeViewFactory ?? 
                                  throw new ArgumentNullException(nameof(upgradeViewFactory));
            _upgradeUiFactory = upgradeUiFactory ?? 
                                throw new ArgumentNullException(nameof(upgradeUiFactory));
            _formService = formService;
            _upgradeUis = gameplayHud.UpgradeUis ?? 
                          throw new NullReferenceException(nameof(gameplayHud.UpgradeUis));
            _upgradeViews = gameplayHud.UpgradeViews ?? 
                          throw new NullReferenceException(nameof(gameplayHud.UpgradeUis));
        }

        private void Enable()
        {
            _playerWallet.CoinsChanged += OnUpgradeFormChanged;
        }

        private void Disable()
        {
            _playerWallet.CoinsChanged -= OnUpgradeFormChanged;
        }

        private void OnUpgradeFormChanged()
        {
            IReadOnlyList<Upgrader> upgraders = _upgradeCollectionService.GetUpgraders();
            List<Upgrader> awaiableUpgraders = new List<Upgrader>();

            foreach (Upgrader upgrader in upgraders)
            {
                if(upgrader.MoneyPerUpgrades[upgrader.CurrentLevel] <= _playerWallet.Coins)
                    awaiableUpgraders.Add(upgrader);
            }

            if (awaiableUpgraders.Count >= 3)
            {
                for (int i = 0; i < 3; i++)
                {
                    _upgradeUiFactory.Create(awaiableUpgraders[i], _upgradeUis[i]);
                    _upgradeViewFactory.Create(awaiableUpgraders[i], _playerWallet, _upgradeViews[i]);
                }
                
                _formService.Show<UpgradeFormView>();
            }
        }
    }
}
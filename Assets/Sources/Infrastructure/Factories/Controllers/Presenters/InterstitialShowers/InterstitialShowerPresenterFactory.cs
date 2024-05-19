using System;
using JetBrains.Annotations;
using Sources.Controllers.Presenters.InterstitialShowers;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.InfrastructureInterfaces.Services.Upgrades;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.InterstitialShowers
{
    public class InterstitialShowerPresenterFactory
    {
        private readonly IInterstitialAdService _interstitialAdService;
        private readonly IFormService _formService;
        private readonly IUpgradeService _upgradeService;

        public InterstitialShowerPresenterFactory(
            IInterstitialAdService interstitialAdService,
            IFormService formService,
            IUpgradeService upgradeService)
        {
            _interstitialAdService = interstitialAdService ??
                                     throw new ArgumentNullException(nameof(interstitialAdService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _upgradeService = upgradeService ?? throw new ArgumentNullException(nameof(upgradeService));
        }
        
        public InterstitialShowerPresenter Create(
            IEnemySpawner enemySpawner, 
            IUpgradeController upgradeController,
            IInterstitialShowerView view)
        {
            return new InterstitialShowerPresenter(
                enemySpawner, 
                upgradeController,
                view, 
                _interstitialAdService, 
                _formService,
                _upgradeService);
        }
    }
}
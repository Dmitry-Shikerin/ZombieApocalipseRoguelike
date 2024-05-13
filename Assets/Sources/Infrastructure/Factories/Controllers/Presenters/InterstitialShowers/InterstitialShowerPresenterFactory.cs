using System;
using JetBrains.Annotations;
using Sources.Controllers.Common.InterstitialShowers;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;
using Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.InterstitialShowers
{
    public class InterstitialShowerPresenterFactory
    {
        private readonly IInterstitialAdService _interstitialAdService;
        private readonly IFormService _formService;

        public InterstitialShowerPresenterFactory(
            IInterstitialAdService interstitialAdService,
            IFormService formService)
        {
            _interstitialAdService = interstitialAdService ??
                                     throw new ArgumentNullException(nameof(interstitialAdService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }
        
        public InterstitialShowerPresenter Create(IEnemySpawner enemySpawner, IInterstitialShowerView view)
        {
            return new InterstitialShowerPresenter(enemySpawner, view, _interstitialAdService, _formService);
        }
    }
}
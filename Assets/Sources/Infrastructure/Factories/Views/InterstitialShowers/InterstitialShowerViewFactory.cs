using System;
using JetBrains.Annotations;
using Sources.Controllers.Common.InterstitialShowers;
using Sources.DomainInterfaces.Models.Spawners;
using Sources.Infrastructure.Factories.Controllers.Presenters.InterstitialShowers;
using Sources.Presentations.Views.InterstitialShowers;
using Sources.PresentationsInterfaces.Views.InterstitialShowers;

namespace Sources.Infrastructure.Factories.Views.InterstitialShowers
{
    public class InterstitialShowerViewFactory
    {
        private readonly InterstitialShowerPresenterFactory _presenterFactory;

        public InterstitialShowerViewFactory(InterstitialShowerPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IInterstitialShowerView Create(IEnemySpawner enemySpawner, InterstitialShowerView view)
        {
            InterstitialShowerPresenter presenter = _presenterFactory.Create(enemySpawner, view);
            
            view.Construct(presenter);

            return view;
        }
    }
}
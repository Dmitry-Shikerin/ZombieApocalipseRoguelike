using System;
using Sources.Controllers.Presenters.Upgrades;
using Sources.DomainInterfaces.Upgrades;
using Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades;
using Sources.InfrastructureInterfaces.Factories.Views.Upgrades;
using Sources.Presentations.Views.Upgrades;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Views.Upgrades
{
    public class UpgradeDescriptionViewFactory : IUpgradeDescriptionViewFactory
    {
        private readonly UpgradeDescriptionPresenterFactory _presenterFactory;

        public UpgradeDescriptionViewFactory(UpgradeDescriptionPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? 
                                throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IUpgradeDescriptionView Create(IUpgrader upgrader, UpgradeDescriptionView view)
        {
            UpgradeDescriptionPresenter presenter = _presenterFactory.Create(upgrader, view);
            view.Construct(presenter);
            
            return view;
        }
    }
}
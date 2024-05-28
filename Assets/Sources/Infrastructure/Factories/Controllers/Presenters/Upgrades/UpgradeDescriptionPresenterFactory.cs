using System;
using Sources.Controllers.Presenters.Upgrades;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Upgrades
{
    public class UpgradeDescriptionPresenterFactory
    {
        private readonly ILocalizationService _localizationService;

        public UpgradeDescriptionPresenterFactory(ILocalizationService localizationService)
        {
            _localizationService = localizationService ?? 
                                   throw new ArgumentNullException(nameof(localizationService));
        }

        public UpgradeDescriptionPresenter Create(IUpgrader upgrader, IUpgradeDescriptionView view) =>
            new(upgrader, view, _localizationService);
    }
}
using System;
using Sources.Controllers.Common;
using Sources.DomainInterfaces.Models.Upgrades;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.PresentationsInterfaces.Views.Upgrades;

namespace Sources.Controllers.Presenters.Upgrades
{
    public class UpgradeDescriptionPresenter : PresenterBase
    {
        private readonly IUpgrader _upgrader;
        private readonly IUpgradeDescriptionView _view;
        private readonly ILocalizationService _localizationService;

        public UpgradeDescriptionPresenter(
            IUpgrader upgrader, 
            IUpgradeDescriptionView view,
            ILocalizationService localizationService)
        {
            _upgrader = upgrader ?? throw new ArgumentNullException(nameof(upgrader));
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _localizationService = localizationService ?? throw new ArgumentNullException(nameof(localizationService));
        }

        public override void Enable() =>
            UpdateDescriptionText();

        private void UpdateDescriptionText()
        {
            string translatedText = _localizationService.GetText(_upgrader.Id);
            _view.Text.SetText(translatedText);
        }
    }
}
using System;
using Sources.Domain.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;

namespace Sources.Infrastructure.Services.Localizations
{
    public class TestLocalizationService : LocalizationServiceBase
    {
        public TestLocalizationService(
            ILocalizationView localizationView,
            IRussianTranslateService russianTranslateService,
            ITurkishTranslateService turkishTranslateService,
            IEnglishTranslateService englishTranslateService)
            : base(
                localizationView,
                russianTranslateService,
                turkishTranslateService,
                englishTranslateService)
        {
        }

        public override void Translate()
        {
            ITranslateService translator = LocalizationView.Localization switch
            {
                Localization.English => EnglishTranslateService,
                Localization.Turkish => TurkishTranslateService,
                Localization.Russian => RussianTranslateService,
                _ => EnglishTranslateService,
            };

            Translate(translator);
        }
    }
}
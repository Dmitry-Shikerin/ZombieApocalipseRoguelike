using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;

namespace Sources.Infrastructure.Services.Localizations
{
    public abstract class LocalizationServiceBase : ILocalizationService
    {
        protected LocalizationServiceBase(
            ILocalizationView localizationView,
            IRussianTranslateService russianTranslateService,
            ITurkishTranslateService turkishTranslateService,
            IEnglishTranslateService englishTranslateService)
        {
            LocalizationView = localizationView;
            RussianTranslateService = russianTranslateService;
            TurkishTranslateService = turkishTranslateService;
            EnglishTranslateService = englishTranslateService;
        }

        protected ILocalizationView LocalizationView { get; }
        protected IRussianTranslateService RussianTranslateService { get; }
        protected ITurkishTranslateService TurkishTranslateService { get; }
        protected IEnglishTranslateService EnglishTranslateService { get; }

        public abstract void Translate();

        protected void Translate(ITranslateService translateService)
        {
            foreach (ITextView textView in LocalizationView.Texts)
            {
                translateService.Translate(textView);
            }
        }
    }
}
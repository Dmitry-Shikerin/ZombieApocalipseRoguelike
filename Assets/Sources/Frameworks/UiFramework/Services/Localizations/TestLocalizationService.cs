using Sources.Domain.Models.Localizations;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.Presentations.UI.Huds;

namespace Sources.Frameworks.UiFramework.Services.Localizations
{
    public class TestLocalizationService : LocalizationServiceBase
    {
        public TestLocalizationService(
            GameplayHud gameplayHud, 
            ITranslateServiceFactory<IEnglishTranslateService> englishTranslateFactory, 
            ITranslateServiceFactory<IRussianTranslateService> russianTranslateFactory, 
            ITranslateServiceFactory<ITurkishTranslateService> turkishTranslateFactory) 
            : base(
                gameplayHud.UiLocalization, 
                englishTranslateFactory, 
                russianTranslateFactory, 
                turkishTranslateFactory)
        {
        }

        public override void Translate()
        {
            string key = LocalizationView.Localization switch
            {
                Localization.English => "en",
                Localization.Turkish => "tr",
                Localization.Russian => "ru",
                _ => "en",
            };
            
            // Debug.Log("Translate: " + key);
            Translate(key);
        }
    }
}
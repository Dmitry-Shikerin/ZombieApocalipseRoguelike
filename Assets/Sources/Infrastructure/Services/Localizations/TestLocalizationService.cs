using System;
using Sources.Domain.Localizations;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;
using UnityEngine;

namespace Sources.Infrastructure.Services.Localizations
{
    public class TestLocalizationService : LocalizationServiceBase
    {
        public TestLocalizationService(
            ILocalizationView localizationView, 
            ITranslateServiceFactory<IEnglishTranslateService> englishTranslateFactory, 
            ITranslateServiceFactory<IRussianTranslateService> russianTranslateFactory, 
            ITranslateServiceFactory<ITurkishTranslateService> turkishTranslateFactory) 
            : base(
                localizationView, 
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
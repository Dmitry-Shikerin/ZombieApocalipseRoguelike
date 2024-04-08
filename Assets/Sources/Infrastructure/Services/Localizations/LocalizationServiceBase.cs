using System;
using System.Collections.Generic;
using ModestTree.Util;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;

namespace Sources.Infrastructure.Services.Localizations
{
    public abstract class LocalizationServiceBase : ILocalizationService
    {
        private readonly Dictionary<string, Func<ITranslateService>> _translateServiceFactories;
        
        protected LocalizationServiceBase(
            ILocalizationView localizationView,
            ITranslateServiceFactory<IEnglishTranslateService> englishTranslateFactory,
            ITranslateServiceFactory<IRussianTranslateService> russianTranslateFactory,
            ITranslateServiceFactory<ITurkishTranslateService> turkishTranslateFactory)
        {
            LocalizationView = localizationView ?? throw new ArgumentNullException(nameof(localizationView));

            _translateServiceFactories = new Dictionary<string, Func<ITranslateService>>();
            _translateServiceFactories["ru"] = russianTranslateFactory.Create;
            _translateServiceFactories["en"] = englishTranslateFactory.Create;
            _translateServiceFactories["tr"] = turkishTranslateFactory.Create;
        }

        protected ILocalizationView LocalizationView { get; }

        public abstract void Translate();

        protected void Translate(string key)
        {
            if (_translateServiceFactories.ContainsKey(key) == false)
                throw new NullReferenceException(nameof(key));
            
            ITranslateService translateService = _translateServiceFactories[key].Invoke();
            
            foreach (ITextView textView in LocalizationView.Texts)
            {
                translateService.Translate(textView);
            }
        }
    }
}
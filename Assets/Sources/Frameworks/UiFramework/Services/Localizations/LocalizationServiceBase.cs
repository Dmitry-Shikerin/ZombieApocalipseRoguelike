using System;
using System.Collections.Generic;
using Sources.Domain.Models.TextViewTypes;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates.Common;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;

namespace Sources.Frameworks.UiFramework.Services.Localizations
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
            List<ITextView> texts = new List<ITextView>();

            foreach (ITextView textView in LocalizationView.Texts)
            {
                if (textView.TextViewType == TextViewType.Default)
                {
                    texts.Add(textView);
                    continue;
                }

                translateService.Translate(textView);
            }
            // Debug.Log(string.Join(", ", texts.Select(x => (x as TextView).gameObject.name)));
        }
    }
}
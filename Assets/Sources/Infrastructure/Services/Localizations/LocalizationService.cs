using System;
using Sources.InfrastructureInterfaces.Services.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Localizations;
using UnityEngine;

namespace Sources.Infrastructure.Services.Localizations
{
    public class LocalizationService : ILocalizationService
    {
        private readonly ILocalizationView _localizationView;
        private readonly IRussianTranslateService _russianTranslateService;
        private readonly ITurkishTranslateService _turkishTranslateService;
        private readonly IEnglishTranslateService _englishTranslateService;

        public LocalizationService(
            ILocalizationView localizationView,
            IRussianTranslateService russianTranslateService,
            ITurkishTranslateService turkishTranslateService,
            IEnglishTranslateService englishTranslateService)
        {
            _localizationView = localizationView ?? throw new ArgumentNullException(nameof(localizationView));
            _russianTranslateService = russianTranslateService ?? 
                                       throw new ArgumentNullException(nameof(russianTranslateService));
            _turkishTranslateService = turkishTranslateService ?? 
                                       throw new ArgumentNullException(nameof(turkishTranslateService));
            _englishTranslateService = englishTranslateService ?? 
                                       throw new ArgumentNullException(nameof(englishTranslateService));
        }

        public void Translate(string language)
        {
            ITranslateService translator = language switch
            {
                "en"  => _englishTranslateService,
                "tr" => _turkishTranslateService,
                "ru" => _russianTranslateService,
                _ => _englishTranslateService,
            };

            Translate(translator);
        }

        private void Translate(ITranslateService translateService)
        {
            foreach (ITextView textView in _localizationView.Texts)
            {
                string text = translateService.GetTranslate(textView.Id);
                textView.SetText(text);
                Debug.Log(text);
            }
        }
    }
}
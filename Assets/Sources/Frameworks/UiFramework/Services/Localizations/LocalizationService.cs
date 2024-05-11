using System;
using System.Collections.Generic;
using System.Linq;
using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Localizations;
using Sources.Domain.Models.TextViewTypes;
using Sources.Frameworks.UiFramework.Domain.Localizations.Configs;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.Frameworks.UiFramework.Services.Localizations
{
    public class LocalizationService : ILocalizationService
    {
        private readonly UiCollector _uiCollector;
        private readonly List<IUiText> _textViews = new List<IUiText>();
        private readonly Dictionary<string, IReadOnlyDictionary<string, string>> _textDictionary;
        private IReadOnlyDictionary<string, string> _currentLanguageDictionary;

        public LocalizationService(UiCollector uiCollector, LocalizationConfig localizationConfig)
        {
            _uiCollector = uiCollector ? uiCollector : throw new ArgumentNullException(nameof(uiCollector));

            AddTextViews(uiCollector);

            _textDictionary = new Dictionary<string, IReadOnlyDictionary<string, string>>()
            {
                [LocalizationConstant.RussianCode] = localizationConfig.LocalizationPhrases
                    .ToDictionary(phrase => phrase.LocalizationId, phrase => phrase.Russian),
                [LocalizationConstant.EnglishCode] = localizationConfig.LocalizationPhrases
                    .ToDictionary(phrase => phrase.LocalizationId, phrase => phrase.English),
                [LocalizationConstant.TurkishCode] = localizationConfig.LocalizationPhrases
                    .ToDictionary(phrase => phrase.LocalizationId, phrase => phrase.Turkish),
            };
        }
        
        public void Translate()
        {
            //todo вынести в отдельный сервис
            if(WebApplication.IsRunningOnWebGL)
                ChangeSdcLanguage();
            else
                ChangeCollectorLanguage();
        }

        public string GetText(string key)
        {
            if(_currentLanguageDictionary.ContainsKey(key) == false)
                throw new KeyNotFoundException(nameof(key));
            
            return _currentLanguageDictionary[key];
        }

        private void TranslateViews(string key)
        {
            _currentLanguageDictionary = _textDictionary[key];

            foreach (IUiText textView in _textViews)
            {
                if (textView.TextViewType == TextViewType.Default)
                    continue;

                if (_currentLanguageDictionary.ContainsKey(textView.Id) == false)
                    throw new KeyNotFoundException(nameof(textView.Id));

                textView.SetText(_currentLanguageDictionary[textView.Id]);
            }
        }

        private void AddTextViews(UiCollector uiCollector)
        {
            foreach (IUiText textView in uiCollector.UiTexts)
            {
                _textViews.Add(textView);
            }
        }

        private void ChangeCollectorLanguage()
        {
            string key = _uiCollector.Localization switch
            {
                Localization.English => LocalizationConstant.EnglishCode,
                Localization.Turkish => LocalizationConstant.TurkishCode,
                Localization.Russian => LocalizationConstant.RussianCode,
                _ => LocalizationConstant.EnglishCode,
            };

            TranslateViews(key);
        }
        
        private void ChangeSdcLanguage()
        {
            if (WebApplication.IsRunningOnWebGL == false)
                return;

            string languageCode = YandexGamesSdk.Environment.i18n.lang switch
            {
                LocalizationConstant.English => LocalizationConstant.EnglishCode,
                LocalizationConstant.Turkish => LocalizationConstant.TurkishCode,
                LocalizationConstant.Russian => LocalizationConstant.RussianCode,
                _ => LocalizationConstant.EnglishCode
            };

            TranslateViews(languageCode);
        }
    }
}
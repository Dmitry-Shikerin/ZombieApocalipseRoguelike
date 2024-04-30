using System;
using System.Collections.Generic;
using Agava.WebUtility;
using Agava.YandexGames;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Localizations;
using Sources.Domain.Models.TextViewTypes;
using Sources.Frameworks.UiFramework.Domain.Configs.Localizations;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;
using UnityEngine;

namespace Sources.Frameworks.UiFramework.Services.Localizations
{
    public class LocalizationService : ILocalizationService
    {
        private readonly UiCollector _uiCollector;
        private readonly List<UiText> _textViews = new List<UiText>();
        private readonly Dictionary<string, IReadOnlyDictionary<string, string>> _textDictionary;

        public LocalizationService(UiCollector uiCollector, LocalizationConfig localizationConfig)
        {
            _uiCollector = uiCollector ? uiCollector : throw new ArgumentNullException(nameof(uiCollector));

            AddTextViews(uiCollector);

            _textDictionary = new Dictionary<string, IReadOnlyDictionary<string, string>>()
            {
                [LocalizationConstant.RussianCode] = localizationConfig.Russian,
                [LocalizationConstant.EnglishCode] = localizationConfig.English,
                [LocalizationConstant.TurkishCode] = localizationConfig.Turkish,
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

        private void TranslateViews(string key)
        {
            IReadOnlyDictionary<string, string> textDictionary = _textDictionary[key];

            foreach (IUiText textView in _textViews)
            {
                if (textView.TextViewType == TextViewType.Default)
                    continue;

                if (textDictionary.ContainsKey(textView.Id) == false)
                    throw new KeyNotFoundException(nameof(textView.Id));

                textView.SetText(textDictionary[textView.Id]);
            }
        }

        private void AddTextViews(UiCollector uiCollector)
        {
            foreach (UiText textView in uiCollector.UiTexts)
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
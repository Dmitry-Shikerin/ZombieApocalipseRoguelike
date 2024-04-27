using System;
using System.Collections.Generic;
using Sources.Domain.Models.Localizations;
using Sources.Domain.Models.TextViewTypes;
using Sources.Frameworks.UiFramework.Domain.Configs.Localizations;
using Sources.Frameworks.UiFramework.Presentation.Forms;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.Frameworks.UiFramework.Services.Localizations
{
    public class LocalizationService 
        // : ILocalizationService
    {
        private readonly Dictionary<string, TextView> _textViews = new Dictionary<string, TextView>();
        private readonly Dictionary<string, IReadOnlyDictionary<string, string>> _textDictionary;
        
        // public LocalizationService(UiCollector uiCollector, LocalizationConfig localizationConfig)
        // {
        //     AddTextViews(uiCollector);
        //     
        //     _textDictionary = new Dictionary<string, IReadOnlyDictionary<string, string>>()
        //     {
        //         ["ru"] = localizationConfig.Russian,
        //         ["en"] = localizationConfig.English,
        //         ["tr"] = localizationConfig.Turkish,
        //     };
        // }
        //
        // public void Translate()
        // {
        //     string key = LocalizationView.Localization switch
        //     {
        //         Localization.English => "en",
        //         Localization.Turkish => "tr",
        //         Localization.Russian => "ru",
        //         _ => "en",
        //     };
        //     
        //     // Debug.Log("Translate: " + key);
        //     TranslateViews(key);
        //
        // }

        private void TranslateViews(string key)
        {
            IReadOnlyDictionary<string, string> textDictionary = _textDictionary[key];
            
            foreach (ITextView textView in _textViews.Values)
            {
                if (textView.TextViewType == TextViewType.Default)
                    continue;

                if(textDictionary.ContainsKey(textView.Id) == false)
                    throw new KeyNotFoundException(nameof(textView));
                
                textView.SetText(textDictionary[textView.Id]);
            }
        }

        // private void AddTextViews(UiCollector uiCollector)
        // {
        //     foreach (TextView textView in uiCollector.TextViews)
        //     {
        //         if (_textViews.ContainsKey(textView.Id))
        //             throw new InvalidOperationException(nameof(textView));
        //         
        //         _textViews[textView.Id] = textView;
        //     }
        // }
    }
}
using System;
using System.Collections.Generic;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates.Common;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.Frameworks.UiFramework.Services.Localizations.Translates.Common
{
    public abstract class TranslateServiceBase : ITranslateService
    {
        private readonly Dictionary<string, string> _translates = new Dictionary<string, string>();

        protected TranslateServiceBase()
        {
            FillTranslates(_translates);
        }

        public void Translate(IUiText uiText)
        {
            if(_translates.ContainsKey(uiText.Id) == false)
                throw new NullReferenceException("Transleted key not found");
            
            uiText.SetText(_translates[uiText.Id]);
        }

        protected abstract void FillTranslates(Dictionary<string, string> translates);
    }
}
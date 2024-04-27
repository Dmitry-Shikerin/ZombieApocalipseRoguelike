using System;
using System.Collections.Generic;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common;
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

        public void Translate(ITextView textView)
        {
            if(_translates.ContainsKey(textView.Id) == false)
                throw new NullReferenceException("Transleted key not found");
            
            textView.SetText(_translates[textView.Id]);
        }

        protected abstract void FillTranslates(Dictionary<string, string> translates);
    }
}
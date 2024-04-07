using System;
using System.Collections.Generic;
using Sources.InfrastructureInterfaces.Services.Localizations;

namespace Sources.Infrastructure.Services.Localizations.Translates.Common
{
    public abstract class TranslateServiceBase : ITranslateService
    {
        protected Dictionary<string, string> Translates = new Dictionary<string, string>();

        protected TranslateServiceBase()
        {
            FillTranslates();
        }

        public string GetTranslate(string key)
        {
            if(Translates.ContainsKey(key) == false)
                throw new NullReferenceException("Transleted key not found");
            
            return Translates[key];
        }

        protected abstract void FillTranslates();
    }
}
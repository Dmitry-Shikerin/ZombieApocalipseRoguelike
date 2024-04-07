using System.Collections.Generic;
using Sources.Infrastructure.Services.Localizations.Translates.Common;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;

namespace Sources.Infrastructure.Services.Localizations.Translates
{
    public class EnglishTranslateService : TranslateServiceBase, IEnglishTranslateService
    {
        //TODO как переделать это на Json?
        protected override void FillTranslates(Dictionary<string, string> translates)
        {
            translates["Main Menu"] = "Main Menu";
        }
    }
}
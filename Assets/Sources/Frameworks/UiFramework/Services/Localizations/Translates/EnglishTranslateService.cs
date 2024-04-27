using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Services.Localizations.Translates.Common;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;

namespace Sources.Frameworks.UiFramework.Services.Localizations.Translates
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
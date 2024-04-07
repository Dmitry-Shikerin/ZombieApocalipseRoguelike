using Sources.Infrastructure.Services.Localizations.Translates.Common;

namespace Sources.Infrastructure.Services.Localizations.Translates
{
    public class EnglishTranslateService : TranslateServiceBase, IEnglishTranslateService
    {
        //TODO как переделать это на Json?
        protected override void FillTranslates()
        {
            Translates["Main Menu"] = "Main Menu";
        }
    }
}
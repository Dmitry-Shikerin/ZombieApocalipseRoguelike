using Sources.Infrastructure.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations.Translates;

namespace Sources.Infrastructure.Factories.Services.Localizations
{
    public class EnglishTranslateServiceFactory : ITranslateServiceFactory<IEnglishTranslateService>
    {
        public IEnglishTranslateService Create() =>
            new EnglishTranslateService();
    }
}
using Sources.Infrastructure.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;

namespace Sources.Infrastructure.Factories.Services.Localizations
{
    public class RussianTranslateServiceFactory : ITranslateServiceFactory<IRussianTranslateService>
    {
        public IRussianTranslateService Create() =>
            new RussianTranslateService();
    }
}
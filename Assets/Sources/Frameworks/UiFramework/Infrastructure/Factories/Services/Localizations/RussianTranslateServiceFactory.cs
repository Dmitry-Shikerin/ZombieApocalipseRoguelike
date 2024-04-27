using Sources.Frameworks.UiFramework.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Localizations
{
    public class RussianTranslateServiceFactory : ITranslateServiceFactory<IRussianTranslateService>
    {
        public IRussianTranslateService Create() =>
            new RussianTranslateService();
    }
}
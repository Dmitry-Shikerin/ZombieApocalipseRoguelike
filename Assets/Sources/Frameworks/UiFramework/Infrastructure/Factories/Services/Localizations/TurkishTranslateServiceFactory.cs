using Sources.Frameworks.UiFramework.Services.Localizations.Translates;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates;
using Sources.InfrastructureInterfaces.Factories.Services;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Localizations
{
    public class TurkishTranslateServiceFactory : ITranslateServiceFactory<ITurkishTranslateService>
    {
        public ITurkishTranslateService Create() =>
            new TurkishTranslateService();
    }
}
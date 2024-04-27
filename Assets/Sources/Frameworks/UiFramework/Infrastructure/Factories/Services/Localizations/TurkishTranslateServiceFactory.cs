using Sources.Frameworks.UiFramework.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.Localizations
{
    public class TurkishTranslateServiceFactory : ITranslateServiceFactory<ITurkishTranslateService>
    {
        public ITurkishTranslateService Create() =>
            new TurkishTranslateService();
    }
}
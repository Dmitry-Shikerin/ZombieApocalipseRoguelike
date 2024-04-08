using Sources.Infrastructure.Services.Localizations.Translates;
using Sources.InfrastructureInterfaces.Factories.Services;
using Sources.InfrastructureInterfaces.Services.Localizations;

namespace Sources.Infrastructure.Factories.Services.Localizations
{
    public class TurkishTranslateServiceFactory : ITranslateServiceFactory<ITurkishTranslateService>
    {
        public ITurkishTranslateService Create() =>
            new TurkishTranslateService();
    }
}
using Sources.InfrastructureInterfaces.Services.Localizations.Translates.Common;

namespace Sources.InfrastructureInterfaces.Factories.Services
{
    public interface ITranslateServiceFactory<out T>
        where T : ITranslateService
    {
        public T Create();
    }
}
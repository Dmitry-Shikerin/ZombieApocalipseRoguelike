using Sources.Frameworks.UiFramework.ServicesInterfaces.Localizations.Translates.Common;

namespace Sources.InfrastructureInterfaces.Factories.Services
{
    public interface ITranslateServiceFactory<out T>
        where T : ITranslateService
    {
        public T Create();
    }
}
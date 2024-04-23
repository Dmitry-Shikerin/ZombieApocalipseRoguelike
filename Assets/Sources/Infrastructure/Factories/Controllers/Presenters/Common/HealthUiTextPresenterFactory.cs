using Sources.Controllers.Common;
using Sources.DomainInterfaces.Healths;
using Sources.PresentationsInterfaces.Views.Common;

namespace Sources.Infrastructure.Factories.Controllers.Common
{
    public class HealthUiTextPresenterFactory
    {
        public HealthUiTextPresenter Create(IHealth health, IHealthUiText healthUiText)
        {
            return new HealthUiTextPresenter(health, healthUiText);
        }
    }
}
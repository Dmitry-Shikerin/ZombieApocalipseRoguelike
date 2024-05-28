using Sources.Controllers.Presenters.Common;
using Sources.DomainInterfaces.Models.Healths;
using Sources.PresentationsInterfaces.Views.Common;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Common
{
    public class HealthUiPresenterFactory
    {
        public HealthUiPresenter Create(IHealth health, IHealthUi healthUi)
        {
            return new HealthUiPresenter(health, healthUi);
        }
    }
}
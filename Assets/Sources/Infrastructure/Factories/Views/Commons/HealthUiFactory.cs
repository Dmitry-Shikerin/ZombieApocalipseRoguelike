using System;
using Sources.Controllers.Common;
using Sources.Controllers.Presenters.Common;
using Sources.DomainInterfaces.Models.Healths;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Presentations.Views.Common;
using Sources.PresentationsInterfaces.Views.Common;

namespace Sources.Infrastructure.Factories.Views.Commons
{
    public class HealthUiFactory
    {
        private readonly HealthUiPresenterFactory _healthUiPresenterFactory;

        public HealthUiFactory(HealthUiPresenterFactory healthUiPresenterFactory)
        {
            _healthUiPresenterFactory = healthUiPresenterFactory ?? 
                                        throw new ArgumentNullException(nameof(healthUiPresenterFactory));
        }

        public IHealthUi Create(IHealth health, HealthUi healthUi)
        {
            HealthUiPresenter healthUiPresenter = _healthUiPresenterFactory.Create(health, healthUi);
            
            healthUi.Construct(healthUiPresenter);
            
            return healthUi;
        }
    }
}
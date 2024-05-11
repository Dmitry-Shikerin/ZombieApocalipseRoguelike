using System;
using Sources.Controllers.Common;
using Sources.Controllers.Presenters.Common;
using Sources.DomainInterfaces.Healths;
using Sources.Infrastructure.Factories.Controllers.Common;
using Sources.Presentations.Views.Common;
using Sources.PresentationsInterfaces.Views.Common;

namespace Sources.Infrastructure.Factories.Views.Commons
{
    public class HealthUiTextViewFactory
    {
        private readonly HealthUiTextPresenterFactory _healthUiTextViewFactory;

        public HealthUiTextViewFactory(HealthUiTextPresenterFactory healthUiTextViewFactory)
        {
            _healthUiTextViewFactory = healthUiTextViewFactory ?? 
                                       throw new ArgumentNullException(nameof(healthUiTextViewFactory));
        }

        public IHealthUiText Create(IHealth health, HealthUiText healthUiText)
        {
            HealthUiTextPresenter presenter = _healthUiTextViewFactory.Create(health, healthUiText);

            healthUiText.Construct(presenter);
            
            return healthUiText;
        }
    }
}
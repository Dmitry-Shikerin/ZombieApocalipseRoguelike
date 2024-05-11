using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Constants;
using Sources.DomainInterfaces.Healths;
using Sources.PresentationsInterfaces.Views.Common;
using Sources.Utils.Extentions;

namespace Sources.Controllers.Presenters.Common
{
    public class HealthUiPresenter : PresenterBase
    {
        private readonly IHealth _health;
        private readonly IHealthUi _healthUi;

        public HealthUiPresenter(IHealth health, IHealthUi healthUi)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healthUi = healthUi ?? throw new ArgumentNullException(nameof(healthUi));
        }

        public override void Enable()
        {
            OnHealthChanged();
            _health.HealthChanged += OnHealthChanged;
        }

        public override void Disable() =>
            _health.HealthChanged -= OnHealthChanged;

        private void OnHealthChanged()
        {
            float percent = _health.CurrentHealth.FloatToPercent(_health.MaxHealth);
            float fillAmount = percent * MathConstant.UnitMultiplier;
            
            _healthUi.HealthImage.SetFillAmount(fillAmount);
        }
    }
}
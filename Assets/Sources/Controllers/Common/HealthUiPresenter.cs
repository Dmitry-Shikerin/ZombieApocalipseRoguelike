using System;
using Sources.DomainInterfaces.Healths;
using Sources.PresentationsInterfaces.Views.Common;

namespace Sources.Controllers.Common
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
            _health.HealthChanged += OnHealthChanged;
        }

        public override void Disable()
        {
            _health.HealthChanged += OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            float percent = _health.MaxHealth / 100f;
            int currentPercents = 0;
            float currentHealth = 0;

            while (currentHealth < _health.CurrentHealth)
            {
                currentHealth += percent;
                currentPercents++;
            }
            
            _healthUi.HealthImage.SetFillAmount(currentPercents * 0.01f);
        }
    }
}
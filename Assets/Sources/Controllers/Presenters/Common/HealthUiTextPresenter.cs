using System;
using System.Linq;
using System.Threading;
using Sirenix.Utilities;
using Sources.DomainInterfaces.Healths;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Common;
using UnityEngine;

namespace Sources.Controllers.Common
{
    public class HealthUiTextPresenter : PresenterBase
    {
        private readonly IHealth _health;
        private readonly IHealthUiText _healthUiText;

        private CancellationTokenSource _cancellationTokenSource;

        public HealthUiTextPresenter(IHealth health, IHealthUiText healthUiText)
        {
            _health = health ?? throw new ArgumentNullException(nameof(health));
            _healthUiText = healthUiText ?? throw new ArgumentNullException(nameof(healthUiText));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            HideAllTexts();
            _health.DamageReceived += OnDamageReceived;
        }

        public override void Disable()
        {
            _health.DamageReceived -= OnDamageReceived;
            
            _cancellationTokenSource.Cancel();
        }

        private void OnDamageReceived(float damage)
        {
            IUiText uiText = _healthUiText.DamageTexts
                .FirstOrDefault(text => text.IsHide);

            if (uiText == null)
            {
                //TODO сделать добавление в очередь и вытаскивать оттуда текст
                //TODO нужно ли создавать новый токен?
                _cancellationTokenSource.Cancel();

                _healthUiText.DamageTexts.ForEach(text => text.SetIsHide(true));
                _healthUiText.DamageTexts.ForEach(text => text.SetTextColor(Color.clear));
                
                _cancellationTokenSource = new CancellationTokenSource();
                uiText = _healthUiText.DamageTexts
                    .FirstOrDefault(text => text.IsHide);
            }
            
            uiText.SetTextColor(Color.red);
            uiText.SetIsHide(false);
            uiText.SetText(damage.ToString());
            uiText.SetClearColorAsync(_cancellationTokenSource.Token);
        }

        private void HideAllTexts() =>
            _healthUiText.DamageTexts.ForEach(text => text.SetText(string.Empty));
    }
}
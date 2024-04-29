﻿using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Presentation.Forms.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class UiFormButtonClickService : ICustomButtonClickService
    {
        private readonly IFormService _formService;
        private readonly CustomButtonClickServiceCollection _customButtonClickServiceCollection;
        private CancellationTokenSource _cancellationTokenSource;

        public UiFormButtonClickService(
            IFormService formService,
            CustomButtonClickServiceCollection customButtonClickServiceCollection)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _customButtonClickServiceCollection =
                customButtonClickServiceCollection ??
                throw new ArgumentNullException(nameof(customButtonClickServiceCollection));
        }

        public void Enable(UiButton button)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            if (button.ButtonId == ButtonId.Default || button.FormId != FormId.Default)
                return;

            _customButtonClickServiceCollection.Get(button).Enable(button);
        }

        public void Disable(UiButton button)
        {
            _cancellationTokenSource.Cancel();

            if (button.ButtonId == ButtonId.Default || button.FormId != FormId.Default)
                return;

            _customButtonClickServiceCollection.Get(button).Disable(button);
        }

        public async void OnClick(UiButton button)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                if (button.UseButtonType == UseButtonType.Delayed)
                    await UniTask.Delay(TimeSpan.FromMilliseconds(button.Delay),
                        cancellationToken: _cancellationTokenSource.Token,
                        ignoreTimeScale: true);

                ButtonClick(button);
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void ButtonClick(UiButton button)
        {
            if (button.ButtonId == ButtonId.Default && button.FormId != FormId.Default)
                _formService.Show(button.FormId);
            else if (button.ButtonId != ButtonId.Default)
                _customButtonClickServiceCollection.Get(button).OnClick(button);
            else
                throw new InvalidOperationException(nameof(button));
        }
    }
}
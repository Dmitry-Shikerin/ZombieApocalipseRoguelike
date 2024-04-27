using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers
{
    public class UiFormButtonClickService : IButtonService
    {
        private readonly IFormService _formService;
        private CancellationTokenSource _cancellationTokenSource;

        public UiFormButtonClickService(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
        }

        public void Disable()
        {
            _cancellationTokenSource.Cancel();
        }

        public async void OnClick(UiFormButton button)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                if (button.UseButtonType == UseButtonType.Delayed)
                    await UniTask.Delay(TimeSpan.FromMilliseconds(button.Delay),
                        cancellationToken: _cancellationTokenSource.Token, 
                        ignoreTimeScale: true);

                _formService.Show(button.FormId);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}
using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Services.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Buttons
{
    public class FormButtonPresenter : FormButtonPresenterBase
    {
        private readonly FormService _formService;
        private readonly UiFormButton _view;
        private CancellationTokenSource _cancellationTokenSource;
        private readonly IButtonService _buttonService;

        public FormButtonPresenter(
            UiFormButton view,
            FormService formService,
            ButtonServiceCollection buttonServiceCollection)
        {
            _buttonService = buttonServiceCollection.GetButtonService(view.FormId);
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _buttonService.Enable();
            _view.AddClickListener(ShowForm);
        }

        public override void Disable()
        {
            _buttonService.Disable();
            _cancellationTokenSource.Cancel();
            _view.RemoveClickListener(ShowForm);
        }

        private async void ShowForm()
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource = new CancellationTokenSource();

            try
            {
                if (_view.UseButtonType == UseButtonType.Delayed)
                    await UniTask.Delay(TimeSpan.FromMilliseconds(_view.Delay),
                        cancellationToken: _cancellationTokenSource.Token);

                _formService.Show(_view.FormId);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}
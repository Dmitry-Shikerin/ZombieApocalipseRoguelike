using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.ServicesInterfaces.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Buttons
{
    public class FormButtonPresenter : FormButtonPresenterBase
    {
        private readonly IFormService _formService;
        private readonly UiFormButton _view;
        private CancellationTokenSource _cancellationTokenSource;

        public FormButtonPresenter(UiFormButton view, IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            
            _view.AddClickListener(ShowForm);
        }

        public override void Disable()
        {
            _view.RemoveClickListener(ShowForm);
            _cancellationTokenSource.Cancel();
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
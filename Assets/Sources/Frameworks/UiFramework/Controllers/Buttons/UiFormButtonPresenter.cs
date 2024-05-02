using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Frameworks.UiFramework.Infrastructure.Services.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;

namespace Sources.Frameworks.UiFramework.Controllers.Buttons
{
    public class UiFormButtonPresenter : PresenterBase
    {
        private readonly UiButtonViewService _uiButtonViewService;
        private readonly UiUiUiUiButton _view;

        private CancellationTokenSource _cancellationTokenSource;

        public UiFormButtonPresenter(
            UiUiUiUiButton view,
            UiButtonViewService uiButtonViewService)
        {
            _uiButtonViewService = uiButtonViewService ??
                                   throw new ArgumentNullException(nameof(uiButtonViewService));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _cancellationTokenSource = new CancellationTokenSource();
            _view.AddClickListener(ShowForm);
            _uiButtonViewService.Handle(_view.EnableCommandId, _view);
        }

        public override void Disable()
        {
            _view.RemoveClickListener(ShowForm);
            _uiButtonViewService.Handle(_view.DisableCommandId, _view);
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
                        cancellationToken: _cancellationTokenSource.Token,
                        ignoreTimeScale: true);

                _uiButtonViewService.Handle(_view.OnClickCommandId, _view);
            }
            catch (OperationCanceledException)
            {
            }
        }
    }
}
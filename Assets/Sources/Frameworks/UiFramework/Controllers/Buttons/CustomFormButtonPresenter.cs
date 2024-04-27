using System;
using Cysharp.Threading.Tasks;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Services.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Buttons
{
    public class CustomFormButtonPresenter : FormButtonPresenterBase
    {
        private readonly Action _action;
        private readonly FormService _formService;
        private readonly UiFormButton _view;

        public CustomFormButtonPresenter(
            UiFormButton view,
            FormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _formService.GetEnabledButtonAction(_view.ButtonId)?.Invoke(_view);
            _view.AddClickListener(OnClickAction);
        }

        public override void Disable() =>
            _view.RemoveClickListener(OnClickAction);

        private async void OnClickAction()
        {
            if (_view.UseButtonType == UseButtonType.Delayed)
                await UniTask.Delay(TimeSpan.FromMilliseconds(_view.Delay));
            
            _formService.GetButtonAction(_view.ButtonId).Invoke();
        }
    }
}
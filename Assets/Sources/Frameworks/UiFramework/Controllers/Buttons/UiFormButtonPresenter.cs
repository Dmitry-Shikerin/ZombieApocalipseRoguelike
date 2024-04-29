using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Sources.Controllers.Common;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices;
using Sources.Frameworks.UiFramework.Infrastructure.Factories.Services.ButtonServices.Controllers;
using Sources.Frameworks.UiFramework.Presentation.Buttons;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Services.Forms;

namespace Sources.Frameworks.UiFramework.Controllers.Buttons
{
    public class UiFormButtonPresenter : PresenterBase
    {
        private readonly FormService _formService;
        private readonly UiFormButtonClickService _buttonClickService;
        private readonly UiButton _view;
        private readonly IButtonService _buttonService;

        public UiFormButtonPresenter(
            UiButton view,
            FormService formService,
            ButtonServiceCollection buttonServiceCollection,
            UiFormButtonClickService buttonClickService)
        {
            _buttonService = buttonServiceCollection.GetButtonService(view.FormId);
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _buttonClickService = buttonClickService ?? throw new ArgumentNullException(nameof(buttonClickService));
            _view = view ? view : throw new ArgumentNullException(nameof(view));
        }

        public override void Enable()
        {
            _buttonService.Enable();
            _buttonClickService.Enable(_view);
            _view.AddClickListener(ShowForm);
        }

        public override void Disable()
        {
            _buttonService.Disable();
            _buttonClickService.Disable(_view);
            _view.RemoveClickListener(ShowForm);
        }

        private void ShowForm() =>
            _buttonClickService.OnClick(_view);
    }
}
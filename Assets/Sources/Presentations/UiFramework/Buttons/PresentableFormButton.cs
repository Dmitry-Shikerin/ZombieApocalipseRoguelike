using System;
using Sources.ControllersInterfaces;
using Sources.Presentations.UiFramework.Buttons;

namespace Sources.Presentation.Ui.Buttons
{
    public class PresentableFormButton<T> : ButtonSoundView where T : IPresenter
    {
        protected T Presenter { get; private set; }

        protected override void OnAfterEnable()
        {
            Presenter?.Enable();
        }

        protected override void OnAfterDisable()
        {
            Presenter?.Disable();
        }

        public void Construct(T presenter)
        {
            Hide();
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            Show();
        }

    }
}
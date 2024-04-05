using System;
using Sources.ControllersInterfaces;

namespace Sources.Presentations.Views
{
    public class PresentableView<T> : View where T : IPresenter
    {
        protected T Presenter { get; private set; }

        private void OnEnable()
        {
            Presenter?.Enable();
        }

        private void OnDisable()
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
using System;
using Sources.ControllersInterfaces.Presenters;

namespace Sources.Presentations.Views
{
    public class PresentableView<T> : View
        where T : IPresenter
    {
        protected T Presenter { get; private set; }

        private void OnEnable()
        {
            Presenter?.Enable();
            OnAfterEnable();
        }

        private void OnDisable()
        {
            OnAfterDisable();
            Presenter?.Disable();
        }

        public void Construct(T presenter)
        {
            Hide();
            Presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            Show();
        }

        protected virtual void OnAfterEnable()
        {
        }

        protected virtual void OnAfterDisable()
        {
        }

        protected void DestroyPresenter()
        {
            Presenter.Disable();
            Presenter = default;
        }
    }
}
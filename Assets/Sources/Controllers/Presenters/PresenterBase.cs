using Sources.ControllersInterfaces.Presenters;

namespace Sources.Controllers.Presenters
{
    public abstract class PresenterBase : IPresenter
    {
        public virtual void Enable()
        {
        }

        public virtual void Disable()
        {
        }
    }
}
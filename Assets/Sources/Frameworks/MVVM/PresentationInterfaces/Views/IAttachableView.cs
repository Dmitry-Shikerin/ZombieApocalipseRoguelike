using Sources.Frameworks.MVVM.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Binds.AttachableView
{
    public interface IAttachableView
    {
        void Attach(IBindableView bindableView);
    }
}
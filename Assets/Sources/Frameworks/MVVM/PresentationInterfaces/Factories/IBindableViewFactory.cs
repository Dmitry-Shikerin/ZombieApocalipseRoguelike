using Sources.Frameworks.MVVM.Presentations.Views;
using Sources.Frameworks.PresentationInterfaces.Views;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Factories
{
    public interface IBindableViewFactory
    {
        IBindableView Create(string viewPath, string name, IBindableView parent = null);
        IBindableView Create(BindableView view, IBindableView parent = null);
    }
}
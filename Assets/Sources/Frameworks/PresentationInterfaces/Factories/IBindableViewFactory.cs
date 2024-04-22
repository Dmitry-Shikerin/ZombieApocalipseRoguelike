using Sources.Frameworks.PresentationInterfaces.Views;
using Sources.Frameworks.Presentations.Views;

namespace Sources.Frameworks.MVVM.PresentationInterfaces.Factories
{
    public interface IBindableViewFactory
    {
        IBindableView Create(string viewPath, string name, IBindableView parent = null);
        IBindableView Create(BindableView view, IBindableView parent = null);
    }
}
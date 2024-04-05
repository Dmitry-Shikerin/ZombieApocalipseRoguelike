using Assets.Sources.PresentationsInterfaces.Views;

namespace Assets.Sources.Presentations.Views
{
    public class ContainerView : View
    {
        public void AppendChild(IView view) =>
            view.SetParent(transform);
    }
}

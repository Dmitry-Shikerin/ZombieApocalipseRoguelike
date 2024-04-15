using Sources.PresentationsInterfaces.Views;

namespace Sources.PresentationsInterfaces.UI.Sliders
{
    public interface ISliderView : IView
    {
        void SetValue(float value);
    }
}
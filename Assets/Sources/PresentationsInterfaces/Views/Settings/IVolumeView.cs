using Sources.PresentationsInterfaces.UI.Sliders;

namespace Sources.PresentationsInterfaces.Views.Settings
{
    public interface IVolumeView
    {
        ISliderView MusicVolumeSlider { get; }
        ISliderView MiniGunVolumeSlider { get; }
    }
}
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Settings;
using Sources.Presentations.UI.Sliders;
using Sources.PresentationsInterfaces.UI.Sliders;
using Sources.PresentationsInterfaces.Views.Settings;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Settings
{
    public class VolumeView : PresentableView<VolumePresenter>, IVolumeView
    {
        [Required] [SerializeField] private SliderView _musicVolumeSlider;
        [Required] [SerializeField] private SliderView _miniGunVolumeSlider;

        public ISliderView MusicVolumeSlider => _musicVolumeSlider;
        public ISliderView MiniGunVolumeSlider => _miniGunVolumeSlider;
    }
}
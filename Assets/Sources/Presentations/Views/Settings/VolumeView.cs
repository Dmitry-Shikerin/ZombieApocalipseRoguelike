using Sirenix.OdinInspector;
using Sources.Controllers.Settings;
using Sources.Presentations.UI.Sliders;
using Sources.PresentationsInterfaces.UI.Sliders;
using Sources.PresentationsInterfaces.Views.Settings;
using UnityEngine;

namespace Sources.Presentations.Views.Settings
{
    public class VolumeView : PresentableView<VolumePresenter>, IVolumeView
    {
        [Required] [SerializeField] private SliderView _volumeSlider;

        public ISliderView VolumeSlider => _volumeSlider;
    }
}
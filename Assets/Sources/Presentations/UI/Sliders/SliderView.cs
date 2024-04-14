using Sirenix.OdinInspector;
using Sources.Presentations.Views;
using Sources.PresentationsInterfaces.UI.Sliders;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Presentations.UI.Sliders
{
    public class SliderView : View, ISliderView
    {
        [Required] [SerializeField] private Slider _slider;
        
        public void SetValue(float value) =>
            _slider.value = value;
    }
}
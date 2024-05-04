using System.Collections.Generic;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.UI.Sliders;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Settings
{
    public interface IVolumeView
    {
        ISliderView MusicVolumeSlider { get; }
        ISliderView MiniGunVolumeSlider { get; }
    }
}
using System;
using Sources.Controllers.Common;
using Sources.Domain.Setting;
using Sources.PresentationsInterfaces.Views.Settings;

namespace Sources.Controllers.Settings
{
    public class VolumePresenter : PresenterBase
    {
        private readonly Volume _volume;
        private readonly IVolumeView _volumeView;

        public VolumePresenter(Volume volume, IVolumeView volumeView)
        {
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
            _volumeView = volumeView ?? throw new ArgumentNullException(nameof(volumeView));
        }

        public override void Enable()
        {
            _volumeView.VolumeSlider.AddListener(SetVolume);
            _volumeView.VolumeSlider.SetValue(_volume.VolumeValue);
        }

        public override void Disable()
        {
            _volumeView.VolumeSlider.RemoveListener(SetVolume);
        }

        private void SetVolume(float value) =>
            _volume.SetVolume(value);
    }
}
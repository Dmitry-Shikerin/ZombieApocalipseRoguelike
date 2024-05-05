using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Setting;
using Sources.PresentationsInterfaces.Views.Settings;

namespace Sources.Controllers.Presenters.Settings
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
            _volumeView.MusicVolumeSlider.AddListener(SetMusicVolume);
            _volumeView.MiniGunVolumeSlider.AddListener(SetMiniGunVolume);
            _volumeView.MusicVolumeSlider.SetValue(_volume.MusicMusicValue);
        }

        public override void Disable()
        {
            _volumeView.MusicVolumeSlider.RemoveListener(SetMusicVolume);
            _volumeView.MiniGunVolumeSlider.RemoveListener(SetMiniGunVolume);
        }

        private void SetMiniGunVolume(float value) =>
            _volume.MiniGunVolumeValue = value;

        private void SetMusicVolume(float value) =>
            _volume.MusicMusicValue = value;
    }
}
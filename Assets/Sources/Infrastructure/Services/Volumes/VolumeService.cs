using System;
using Sources.Domain.Models.Setting;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Infrastructure.Services.Volumes
{
    public class VolumeService : IVolumeService
    {
        private Volume _volume;

        public event Action MusicVolumeChanged;
        public event Action MiniGunVolumeChanged;

        public float MusicVolume => _volume.MusicMusicValue;
        public float MiniGunVolume => _volume.MiniGunVolumeValue;

        public void Enter(object payload = null)
        {
            OnMusicVolumeChanged();
            _volume.MusicVolumeChanged += OnMusicVolumeChanged;
            _volume.MiniGunVolumeChanged += OnMiniGunVolumeChanged; 
        }

        public void Exit()
        {
            _volume.MusicVolumeChanged -= OnMusicVolumeChanged;
            _volume.MiniGunVolumeChanged -= OnMiniGunVolumeChanged; 
        }

        private void OnMiniGunVolumeChanged() =>
            MiniGunVolumeChanged?.Invoke();

        private void OnMusicVolumeChanged() =>
            MusicVolumeChanged?.Invoke();

        public void Register(Volume volume) =>
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
    }
}
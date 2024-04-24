using System;
using Sources.Domain.Models.Setting;
using Sources.InfrastructureInterfaces.Services.Volumes;

namespace Sources.Infrastructure.Services.Volumes
{
    public class VolumeService : IVolumeService
    {
        private Volume _volume;

        public event Action VolumeChanged;

        public float Volume => _volume.VolumeValue;

        public void Enter(object payload = null)
        {
            OnVolumeChanged();
            _volume.VolumeChanged += OnVolumeChanged;
        }

        public void Exit()
        {
            _volume.VolumeChanged -= OnVolumeChanged;
        }

        private void OnVolumeChanged() =>
            VolumeChanged?.Invoke();

        public void Register(Volume volume) =>
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
    }
}
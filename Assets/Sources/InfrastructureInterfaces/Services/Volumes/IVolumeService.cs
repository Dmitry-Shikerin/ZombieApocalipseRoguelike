using System;
using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Models.Setting;

namespace Sources.InfrastructureInterfaces.Services.Volumes
{
    public interface IVolumeService : IEnterable, IExitable
    {
        event Action MusicVolumeChanged;
        event Action MiniGunVolumeChanged;
        
        float MusicVolume { get; }
        float MiniGunVolume { get; }
        
        void Register(Volume volume);
    }
}
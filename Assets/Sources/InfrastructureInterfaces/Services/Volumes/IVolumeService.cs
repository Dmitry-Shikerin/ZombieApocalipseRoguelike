using System;
using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.Domain.Setting;

namespace Sources.InfrastructureInterfaces.Services.Volumes
{
    public interface IVolumeService : IEnterable, IExitable
    {
        event Action VolumeChanged;
        
        float Volume { get; }
        
        void Register(Volume volume);
    }
}
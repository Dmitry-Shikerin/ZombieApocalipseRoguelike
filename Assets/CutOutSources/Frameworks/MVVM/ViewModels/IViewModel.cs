using System;
using Sources.ControllersInterfaces.ControllerLifetimes;

namespace Sources.ControllersInterfaces.ViewModels
{
    public interface IViewModel : IEnable, IDisable
    {
        event Action Destroyed;
    }
}
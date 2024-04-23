using System;
using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;

namespace Sources.ControllersInterfaces.ViewModels
{
    public interface IViewModel : IEnable, IDisable
    {
        event Action Destroyed;
    }
}
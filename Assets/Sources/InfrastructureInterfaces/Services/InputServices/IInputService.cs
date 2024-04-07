using System;
using Sources.Domain.Inputs;

namespace Sources.InfrastructureInterfaces.Services.InputServices
{
    public interface IInputService
    {
        //TODO как сделать без этого события?
        event Action Attacked;
        
        InputData InputData { get; }
    }
}
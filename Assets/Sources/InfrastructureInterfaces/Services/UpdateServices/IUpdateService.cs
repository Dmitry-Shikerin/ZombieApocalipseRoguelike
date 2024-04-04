using System;
using System.Collections.Generic;
using Sources.InfrastructureInterfaces.Services.Registers;
using Sources.InfrastructureInterfaces.Services.Updates;

namespace Sources.InfrastructureInterfaces.Services.UpdateServices
{
    public interface IUpdateService : IUpdateRegister, IAllUnregister
    {
    }
}
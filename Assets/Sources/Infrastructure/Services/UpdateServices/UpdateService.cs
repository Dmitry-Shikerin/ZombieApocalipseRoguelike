using System;
using System.Collections.Generic;
using Sources.InfrastructureInterfaces.Services.UpdateServices;

namespace Sources.Infrastructure.Services.UpdateServices
{
    public class UpdateService : IUpdateRegister, IUpdateService
    {
        private readonly List<Action<float>> _actions = new List<Action<float>>();
        
        public void Register(Action<float> action) => 
            _actions.Add(action);

        public void UnRegister(Action<float> action) => 
            _actions.Remove(action);

        public void Update(float deltaTime) => 
            _actions.ForEach(action => action.Invoke(deltaTime));

        public void UnregisterAll() => 
            _actions.Clear();

    }
}
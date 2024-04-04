using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Sources.InfrastructureInterfaces.Services.SceneServices;

namespace Sources.Infrastructure.Services.SceneServices
{
    public class SceneService : ISceneService
    {
        private readonly List<Func<string, UniTask>> _enteringHandlers = new List<Func<string, UniTask>>();
        private readonly List<Func<UniTask>> _exitingHandlers = new List<Func<UniTask>>();
        
        private readonly 
        
        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLate(float deltaTime)
        {
            throw new System.NotImplementedException();
        }

        public void Disable()
        {
            throw new System.NotImplementedException();
        }

        public UniTask ChangeSceneAsync(string sceneName, object payload = null)
        {
            throw new System.NotImplementedException();
        }
    }
}
using Sources.Domain.Inputs;
using Sources.InfrastructureInterfaces.Services.InputServices;

namespace Sources.Infrastructure.Services.InputServices
{
    public class NewInputService : IInputService, IInputServiceUpdater
    {
        // private InputManager _inputManager;
        private float _speed;
        public InputData InputData { get; }
        public void Update(float deltaTime)
        {
            
        }
    }
}
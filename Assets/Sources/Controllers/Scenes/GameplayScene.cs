using Sources.ControllersInterfaces.Scenes;
using UnityEngine;

namespace Sources.Controllers.Scenes
{
    public class GameplayScene : IScene
    {
        public void Enter(object payload = null)
        {
            Debug.Log($"Enter {nameof(GameplayScene)}");
        }

        public void Exit()
        {
        }

        public void Update(float deltaTime)
        {
        }

        public void UpdateLate(float deltaTime)
        {
        }

        public void UpdateFixed(float fixedDeltaTime)
        {
        }
    }
}
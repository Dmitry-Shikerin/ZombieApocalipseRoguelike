using Sirenix.OdinInspector;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views;
using Sources.Presentations.Views.Cameras.Points;
using Sources.Presentations.Views.Characters;
using Zenject;

namespace Sources.Infrastructure.Services.GameTesters
{
    public class GameTesterService : View
    {
        private ICameraService _cameraService;

        [Button]
        public void SetPlayerCameraFollow()
        {
            _cameraService.SetFollower<CharacterView>();
        }

        [Button]
        public void SetAllMapCameraFollow()
        {
            _cameraService.SetFollower<AllMapPoint>();
        }

        [Inject]
        public void Construct(ICameraService cameraService)
        {
            _cameraService = cameraService;
        }
    }
}
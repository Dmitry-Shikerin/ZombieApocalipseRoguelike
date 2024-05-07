using Cinemachine;
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Cameras;
using Sources.PresentationsInterfaces.Views.Cameras;
using UnityEngine;

namespace Sources.Presentations.Views.Cameras
{
    public class CinemachineCameraView : PresentableView<CameraPresenter>, ICinemachineCameraView
    {
        [Required] [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;

        public Transform CharacterTransform { get; private set; }
        
        public void Follow(Transform target) =>
            _cinemachineVirtualCamera.Follow = target;
    }
}
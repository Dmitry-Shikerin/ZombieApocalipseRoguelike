using Cinemachine;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Sources.Presentations.Views.Cameras
{
    public class CinemachineCameraView : View, ICinemachineCameraView
    {
        [Required] [SerializeField] private CinemachineVirtualCamera _cinemachineVirtualCamera;
        
        public void Follow(Transform target) =>
            _cinemachineVirtualCamera.Follow = target;
    }
}
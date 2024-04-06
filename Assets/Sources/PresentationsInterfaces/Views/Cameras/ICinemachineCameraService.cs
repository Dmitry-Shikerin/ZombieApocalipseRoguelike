using UnityEngine;

namespace Sources.Presentations.Views.Cameras
{
    public interface ICinemachineCameraService
    {
        void Follow(Transform target);
    }
}
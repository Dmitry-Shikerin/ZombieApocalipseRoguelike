using UnityEngine;

namespace Sources.Presentations.Views.Cameras
{
    public interface ICinemachineCameraView
    {
        void Follow(Transform target);
    }
}
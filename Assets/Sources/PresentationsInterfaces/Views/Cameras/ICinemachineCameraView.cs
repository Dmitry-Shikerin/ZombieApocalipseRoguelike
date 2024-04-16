using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Cameras
{
    public interface ICinemachineCameraView
    {
        Transform CharacterTransform { get; }
        
        void Follow(Transform target);
    }
}
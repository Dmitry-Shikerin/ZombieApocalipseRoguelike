using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Cameras
{
    public interface ICinemachineCameraView : IView
    {
        Transform CharacterTransform { get; }
        
        void Follow(Transform target);
    }
}
using Sources.PresentationsInterfaces.Views.Cameras.Points;
using UnityEngine;

namespace Sources.Presentations.Views.Cameras.Points
{
    public class AllMapPoint : View, ICameraFollowable
    {
        public Transform Transform => transform;
    }
}
using Sources.Presentations.Views.Cameras.Types;
using Sources.PresentationsInterfaces.Views.Cameras.Points;
using UnityEngine;

namespace Sources.Presentations.Views.Cameras.Points
{
    public class AllMapPoint : View, ICameraFollowable
    {
        [SerializeField] private FollowableId _followableId = FollowableId.AllMap;

        public FollowableId Id => _followableId;

        public Transform Transform => transform;
    }
}
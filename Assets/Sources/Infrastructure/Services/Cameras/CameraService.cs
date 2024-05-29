using System;
using System.Collections.Generic;
using Sources.InfrastructureInterfaces.Services.Cameras;
using Sources.Presentations.Views.Cameras.Types;
using Sources.PresentationsInterfaces.Views.Cameras.Points;

namespace Sources.Infrastructure.Services.Cameras
{
    public class CameraService : ICameraService
    {
        private Dictionary<FollowableId, ICameraFollowable> _cameraTargets = new Dictionary<FollowableId, ICameraFollowable>();

        public event Action FollowableChanged;

        public ICameraFollowable CurrentFollower { get; private set; }

        public void SetFollower(FollowableId id)
        {
            if (_cameraTargets.ContainsKey(id) == false)
                throw new InvalidOperationException(nameof(id));

            CurrentFollower = _cameraTargets[id];
            FollowableChanged?.Invoke();
        }

        public void Add(ICameraFollowable cameraFollowable)
        {
            if (_cameraTargets.ContainsKey(cameraFollowable.Id))
                throw new InvalidOperationException(nameof(cameraFollowable.Id));

            _cameraTargets[cameraFollowable.Id] = cameraFollowable;
        }

        public ICameraFollowable Get(FollowableId id)
        {
            if (_cameraTargets.ContainsKey(id) == false)
                throw new InvalidOperationException(nameof(id));

            return _cameraTargets[id];
        }
    }
}
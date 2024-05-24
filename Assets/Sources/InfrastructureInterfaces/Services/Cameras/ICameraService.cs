using System;
using Sources.ControllersInterfaces.ControllerLifetimes;
using Sources.InfrastructureInterfaces.Services.StatesLifetimes;
using Sources.Presentations.Views.Cameras.Types;
using Sources.PresentationsInterfaces.Views.Cameras.Points;
using UnityEngine;

namespace Sources.InfrastructureInterfaces.Services.Cameras
{
    public interface ICameraService
    {
        event Action FollowableChanged;
        
        ICameraFollowable CurrentFollower { get; }

        void SetFollower(FollowableId followableId);
        public void Add(ICameraFollowable cameraFollowable);
        public ICameraFollowable Get(FollowableId id);
    }
}
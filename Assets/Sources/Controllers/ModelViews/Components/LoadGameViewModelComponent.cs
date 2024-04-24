using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class LoadGameViewModelComponent : IViewModelComponent
    {
        private readonly ISceneService _sceneService;

        public LoadGameViewModelComponent(ISceneService sceneService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }
        public void Enable()
        {
        }

        public void Disable()
        {
        }
        
        [UsedImplicitly]
        [MethodBinding(typeof(IButtonClickMethodBind), "LoadGame_Button")]
        private void OnClick(Vector3 position)
        {
            
        }
    }
}
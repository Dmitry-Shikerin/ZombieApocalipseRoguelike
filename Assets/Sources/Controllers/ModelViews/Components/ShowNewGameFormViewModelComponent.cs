﻿using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class ShowNewGameFormViewModelComponent : IViewModelComponent
    {
        private readonly ISceneService _sceneService;
        private readonly IFormService _formService;
        private readonly ILoadService _loadService;

        public ShowNewGameFormViewModelComponent(
            ISceneService sceneService,
            IFormService formService,
            ILoadService loadService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
        }
        public void Enable()
        {
        }

        public void Disable()
        {
        }
        
        [UsedImplicitly]
        [MethodBinding(typeof(IButtonClickMethodBind), "ToNewGameForm_Button")]
        private void OnClick(Vector3 position)
        {
            _loadService.ClearAll();
            _formService.Show<NewGameForm>();
        }
    }
}
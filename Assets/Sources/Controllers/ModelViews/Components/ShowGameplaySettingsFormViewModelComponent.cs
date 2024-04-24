﻿using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class ShowGameplaySettingsFormViewModelComponent : IViewModelComponent
    {
        private readonly IFormService _formService;

        public ShowGameplaySettingsFormViewModelComponent(IFormService formService)
        {
            _formService = formService ??
                                 throw new ArgumentNullException(nameof(formService));
        }
        public void Enable()
        {
        }

        public void Disable()
        {
        }
        
        [UsedImplicitly]
        [MethodBinding(typeof(IButtonClickMethodBind), "ToSettingsForm_Button")]
        private void OnClick(Vector3 position)
        {
            _formService.Show<GameplaySettingsForm>();
        }
    }
}
﻿using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class ShowWarningNewGameFormViewModelComponent : IViewModelComponent
    {
        private readonly IDomainFormService _domainFormService;

        public ShowWarningNewGameFormViewModelComponent(IDomainFormService domainFormService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
        }
        public void Enable()
        {
        }

        public void Disable()
        {
        }
        
        [UsedImplicitly]
        [MethodBinding(typeof(IButtonClickMethodBind), "ToWarningNewGameForm_Button")]
        private void OnClick(Vector3 position)
        {
            _domainFormService.Show<WarningNewGameForm>();
        }
    }
}
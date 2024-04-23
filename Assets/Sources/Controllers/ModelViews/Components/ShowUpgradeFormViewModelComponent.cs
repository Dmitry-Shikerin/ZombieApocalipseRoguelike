using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Forms.Gameplay;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class ShowUpgradeFormViewModelComponent : IViewModelComponent
    {
        private readonly IFormService _formService;

        public ShowUpgradeFormViewModelComponent(IFormService formService)
        {
            _formService = formService ?? throw new ArgumentNullException(nameof(formService));
        }

        public void Enable()
        {
            
        }

        public void Disable()
        {
        }
        
        [UsedImplicitly]
        [MethodBinding(typeof(IButtonClickMethodBind), "ToUpgradeForm_Button")]
        private void OnClick(Vector3 position)
        {
            _formService.Show<UpgradeForm>();
        }
    }
}
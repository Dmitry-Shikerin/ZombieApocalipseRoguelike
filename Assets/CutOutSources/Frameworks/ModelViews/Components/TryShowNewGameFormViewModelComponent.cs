using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Forms.MainMenu;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class TryShowNewGameFormViewModelComponent : IViewModelComponent
    {
        private readonly IDomainFormService _domainFormService;
        private readonly ILoadService _loadService;

        public TryShowNewGameFormViewModelComponent(
            IDomainFormService domainFormService,
            ILoadService loadService)
        {
            _domainFormService = domainFormService ?? throw new ArgumentNullException(nameof(domainFormService));
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
            if (_loadService.HasKey(ModelId.PlayerWallet))
            {
                Debug.Log("Show warning new game form");
                _domainFormService.Show<WarningNewGameForm>();
                
                return;
            }
            
            Debug.Log("Show warning new game form");
            _domainFormService.Show<NewGameForm>();
        }
    }
}
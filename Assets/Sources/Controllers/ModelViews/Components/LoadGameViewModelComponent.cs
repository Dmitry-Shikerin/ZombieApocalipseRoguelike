using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Payloads;
using Sources.Frameworks.MVVM.Domain.Attributes;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.MVVMFrameworks.DomainInterfaces.Properties;
using Sources.PresentationsInterfaces.Binds.Buttons;
using Sources.PresentationsInterfaces.Binds.Visibilities;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class LoadGameViewModelComponent : IViewModelComponent
    {
        private readonly ISceneService _sceneService;
        private readonly IDataService _dataService;

        [PropertyBinding(typeof(IBindableViewEnabledPropertyBind), "LoadGame_Button")]
        private IBindableProperty<bool> _isEnabled;
        
        public LoadGameViewModelComponent(
            ISceneService sceneService,
            IDataService dataService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }
        
        public void Enable()
        {
            //TODO закостылил
            if (_dataService.HasKey(ModelId.PlayerWallet) == false)
            {
                Debug.Log("Сохранений нет");
                _isEnabled.Value = false;
            }
        }

        public void Disable()
        {
        }
        
        [UsedImplicitly]
        [MethodBinding(typeof(IButtonClickMethodBind), "LoadGame_Button")]
        private void OnClick(Vector3 position)
        {
            _sceneService.ChangeSceneAsync("Gameplay", new ScenePayload("Gameplay", true));
            Debug.Log("Загрузка сохранений");
        }
    }
}
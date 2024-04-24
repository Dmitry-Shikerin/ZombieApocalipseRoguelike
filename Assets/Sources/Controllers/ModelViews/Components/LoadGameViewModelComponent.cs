using System;
using JetBrains.Annotations;
using Sources.ControllersInterfaces.ViewModels;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Payloads;
using Sources.InfrastructureInterfaces.Services.LoadServices.Data;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.MVVMFrameworks.Domain.Attributes;
using Sources.PresentationsInterfaces.Binds.Buttons;
using UnityEngine;

namespace Sources.Controllers.ModelViews.Components
{
    public class LoadGameViewModelComponent : IViewModelComponent
    {
        private readonly ISceneService _sceneService;
        private readonly IDataService _dataService;

        public LoadGameViewModelComponent(
            ISceneService sceneService,
            IDataService dataService)
        {
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
            _dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
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
            if (_dataService.HasKey(ModelId.PlayerWallet) == false)
            {
                Debug.Log("Сохранений нет");
                return;
            }

            _sceneService.ChangeSceneAsync("Gameplay", new ScenePayload("Gameplay", true));
            Debug.Log("Загрузка сохранений");
        }
    }
}
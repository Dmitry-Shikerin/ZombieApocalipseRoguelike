using System;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Payloads;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sources.App.Core
{
    public class AppCore : MonoBehaviour
    {
        private ISceneService _sceneService;

        private void Awake() =>
            DontDestroyOnLoad(this);

        private async void Start()
        {
            //Todo ловлю Аргумент нал
            //Todo добавить переход на main menu
            try
            {
                await _sceneService.ChangeSceneAsync(
                    ModelId.MainMenu,
                    new ScenePayload(ModelId.MainMenu, false, false));
            }
            catch(ArgumentNullException)
            {
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void Update() =>
            _sceneService?.Update(Time.deltaTime);

        private void LateUpdate() =>
            _sceneService?.UpdateLate(Time.deltaTime);

        private void FixedUpdate() =>
            _sceneService?.UpdateFixed(Time.fixedDeltaTime);

        public void Construct(ISceneService sceneService) =>
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
    }
}
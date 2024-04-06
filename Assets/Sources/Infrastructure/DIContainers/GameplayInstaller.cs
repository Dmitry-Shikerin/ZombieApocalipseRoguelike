using System.ComponentModel;
using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Forms.Gameplay;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Controllers.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Factories.Views.Weapons;
using Sources.Infrastructure.Services.Forms;
using Sources.Infrastructure.Services.InputServices;
using Sources.Infrastructure.Services.Linecasts;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Infrastructure.Services.UpdateServices;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        [Required][SerializeField] private GameplayHud _gameplayHud;
        [Required] [SerializeField] private ContainerView _containerView;
        
        public override void InstallBindings()
        {
            Container.Bind<GameplayHud>().FromInstance(_gameplayHud).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            Container.Bind<GameplaySceneViewFactory>().AsSingle();
            
            BindServices();
            BindCharacters();
            BindFormFactories();
            BindWeapons();
            BindBear();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
            Container.Bind<LinecastService>().AsSingle();
            Container.Bind<OverlapService>().AsSingle();
        }

        private void BindFormFactories()
        {
            Container.Bind<GameplayFormServiceFactory>().AsSingle();
            Container.Bind<PauseFormPresenterFactory>().AsSingle();
            Container.Bind<HudFormPresenterFactory>().AsSingle();
        }

        private void BindCharacters()
        {
            Container.Bind<CharacterViewFactory>().AsSingle();
            
            Container.Bind<CharacterMovementPresenterFactory>().AsSingle();
            Container.Bind<CharacterMovementViewFactory>().AsSingle();

            Container.Bind<CharacterAttackerPresenterFactory>().AsSingle();
            Container.Bind<CharacterAttackerViewFactory>().AsSingle();
        }

        private void BindBear()
        {
            Container.Bind<BearPresenterFactory>().AsSingle();
            Container.Bind<BearViewFactory>().AsSingle();
        }

        private void BindWeapons()
        {
            Container.Bind<MiniGunPresenterFactory>().AsSingle();
            Container.Bind<MiniGunViewFactory>().AsSingle();
        }
    }
}
using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.Forms.Common;
using Sources.Infrastructure.Factories.Controllers.Forms.MainMenu;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.SceneViewFactories;
using Sources.Infrastructure.Services.Forms;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views;
using UnityEngine;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class MainMenuInstaller : MonoInstaller
    {
        [Required] [SerializeField] private MainMenuHud _mainMenuHud;
        [Required] [SerializeField] private ContainerView _containerView;

        public override void InstallBindings()
        {
            Container.Bind<MainMenuHud>().FromInstance(_mainMenuHud).AsSingle();
            Container.Bind<ContainerView>().FromInstance(_containerView).AsSingle();
            Container.BindInterfacesAndSelfTo<MainMenuSceneFactory>().AsSingle();
            Container.Bind<MainMenuSceneViewFactory>().AsSingle();
            
            BindServices();
            BindFormFactories();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<FormService>().AsSingle();
        }

        private void BindFormFactories()
        {
            Container.Bind<MainMenuFormServiceFactory>().AsSingle();
            Container.Bind<MainMenuHudFormPresenterFactory>().AsSingle();
            Container.Bind<SettingsFormPresenterFactory>().AsSingle();
            Container.Bind<AuthorizationFormPresenterFactory>().AsSingle();
            Container.Bind<LeaderBoardFormPresenterFactory>().AsSingle();
        }
    }
}
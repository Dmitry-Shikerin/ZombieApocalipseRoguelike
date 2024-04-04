using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Scenes;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Infrastructure.Services.InputServices;
using Sources.Infrastructure.Services.UpdateServices;
using Zenject;

namespace Sources.Infrastructure.DIContainers
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameplaySceneFactory>().AsSingle();
            
            BindServices();
            BindCharacters();
        }

        private void BindServices()
        {
            Container.BindInterfacesAndSelfTo<UpdateService>().AsSingle();
            Container.BindInterfacesAndSelfTo<NewInputService>().AsSingle();
        }

        private void BindCharacters()
        {
            Container.Bind<CharacterViewFactory>().AsSingle();
            
            Container.Bind<CharacterMovementPresenterFactory>().AsSingle();
            Container.Bind<CharacterMovementViewFactory>().AsSingle();
        }
    }
}
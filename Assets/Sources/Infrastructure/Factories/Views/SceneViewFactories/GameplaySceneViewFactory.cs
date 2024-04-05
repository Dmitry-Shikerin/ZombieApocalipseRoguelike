using System;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Characters;
using Sources.Domain.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Forms.Gameplay;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.SceneViewFactories
{
    public class GameplaySceneViewFactory
    {
        private readonly GameplayHud _gameplayHud;
        private readonly GameplayFormServiceFactory _gameplayFormServiceFactory;
        private readonly CharacterViewFactory _characterViewFactory;

        public GameplaySceneViewFactory(
            GameplayHud gameplayHud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            CharacterViewFactory characterViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _characterViewFactory = characterViewFactory
                                    ?? throw new ArgumentNullException(nameof(characterViewFactory));
        }

        public void Create()
        {
            //FormService
            _gameplayFormServiceFactory.Create().Show<HudFormView>();

            //Character
            MiniGun minigun = new MiniGun(20, 0.5f);
            Character character = new Character(
                new CharacterMovement(),
                new CharacterAttacker(minigun),
                minigun);
            CharacterView characterView = Object.FindObjectOfType<CharacterView>();
            _characterViewFactory.Create(character, characterView);
            
            //CinemachineService
            _gameplayHud.CinemachineCameraService.Follow(characterView.transform);
        }
    }
}
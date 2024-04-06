using System;
using Sources.Controllers.Bears.Attacks;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Bears;
using Sources.Domain.Characters;
using Sources.Domain.Weapons;
using Sources.Infrastructure.Factories.Services.FormServices;
using Sources.Infrastructure.Factories.Views.Bears;
using Sources.Infrastructure.Factories.Views.Characters;
using Sources.Presentations.UI.Huds;
using Sources.Presentations.Views.Bears;
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
        private readonly BearViewFactory _bearViewFactory;

        public GameplaySceneViewFactory(
            GameplayHud gameplayHud,
            GameplayFormServiceFactory gameplayFormServiceFactory,
            CharacterViewFactory characterViewFactory,
            BearViewFactory bearViewFactory)
        {
            _gameplayHud = gameplayHud ? gameplayHud : throw new ArgumentNullException(nameof(gameplayHud));
            _gameplayFormServiceFactory = gameplayFormServiceFactory ?? 
                                          throw new ArgumentNullException(nameof(gameplayFormServiceFactory));
            _characterViewFactory = characterViewFactory
                                    ?? throw new ArgumentNullException(nameof(characterViewFactory));
            _bearViewFactory = bearViewFactory ?? throw new ArgumentNullException(nameof(bearViewFactory));
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
            
            //Bear
            BearAttacker bearAttacker = new BearAttacker();
            Bear bear = new Bear(bearAttacker);
            BearView bearView = Object.FindObjectOfType<BearView>();
            _bearViewFactory.Create(bear, bearView);
            bearView.SetTargetFollow(characterView.CharacterMovementView);
            
            //CinemachineService
            _gameplayHud.CinemachineCameraService.Follow(characterView.transform);
        }
    }
}
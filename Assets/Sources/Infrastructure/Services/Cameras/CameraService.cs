using System;
using JetBrains.Annotations;
using Sources.Domain.Gameplay;
using Sources.DomainInterfaces.FirstActions;
using Sources.Presentations.Views.Cameras;
using Sources.PresentationsInterfaces.Views.Character;

namespace Sources.Infrastructure.Services.Cameras
{
    public class CameraService : ICameraService
    {
        private ICinemachineCameraView _cinnemachineCameraView;
        private ICharacterMovementView _characterMovementView;
        private readonly EnemyCounter _enemyCounter;

        public CameraService(
            ICinemachineCameraView cinnemachineCameraView,
            ICharacterMovementView characterMovementView,
            EnemyCounter enemyCounter)
        {
            _cinnemachineCameraView = cinnemachineCameraView ?? 
                                      throw new ArgumentNullException(nameof(cinnemachineCameraView));
            _characterMovementView = characterMovementView ?? 
                                     throw new ArgumentNullException(nameof(characterMovementView));
            _enemyCounter = enemyCounter ?? throw new ArgumentNullException(nameof(enemyCounter));
        }


        public void Enable()
        {
            _enemyCounter.FirstActionActivate += OnFirsKillEnemyAction;
        }

        private void OnFirsKillEnemyAction()
        {
            
        }

        public void Disable()
        {
            throw new NotImplementedException();
        }
    }
}
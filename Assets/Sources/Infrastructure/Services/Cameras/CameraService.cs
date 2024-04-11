using System;
using JetBrains.Annotations;
using Sources.Domain.Gameplay;
using Sources.DomainInterfaces.FirstActions;
using Sources.Presentations.Views.Cameras;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

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

        public void Disable()
        {
            
        }

        private void OnFirsKillEnemyAction()
        {
            Debug.Log("First killEnemyAction");
        }

        private void SHowPanaramaLevelCamera()
        {
            //Todo сделать у камеры вид сверху
            Debug.Log("");
        }

        private void ShowHealthBarTutorial()
        {
            //сделать затемнение экрана у всех туториалов и оставлять подсвеченными только элемент туториала
            //TODO сделать отдельный сервис для формочек туториала
            //сделать 
        }
    }
}
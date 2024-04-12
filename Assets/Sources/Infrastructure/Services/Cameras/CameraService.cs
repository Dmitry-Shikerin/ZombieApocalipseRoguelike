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
        private readonly KillEnemyCounter _killEnemyCounter;

        public CameraService(
            ICinemachineCameraView cinnemachineCameraView,
            ICharacterMovementView characterMovementView,
            KillEnemyCounter killEnemyCounter)
        {
            _cinnemachineCameraView = cinnemachineCameraView ?? 
                                      throw new ArgumentNullException(nameof(cinnemachineCameraView));
            _characterMovementView = characterMovementView ?? 
                                     throw new ArgumentNullException(nameof(characterMovementView));
            _killEnemyCounter = killEnemyCounter ?? throw new ArgumentNullException(nameof(killEnemyCounter));
        }


        public void Enable()
        {
            _killEnemyCounter.FirstActionActivate += OnFirsKillKillEnemyAction;
        }

        public void Disable()
        {
            
        }

        private void OnFirsKillKillEnemyAction()
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
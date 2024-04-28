using System;
using System.ComponentModel;
using Sources.ControllersInterfaces;
using Sources.Domain.Models.Characters;
using Sources.Infrastructure.StateMachines.ContextStateMachines;
using Sources.InfrastructureInterfaces.Services.InputServices;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Controllers.Presenters.Characters.Movements
{
    public class CharacterMovementPresenter : ContextStateMachine, IPresenter
    {
        private readonly CharacterMovement _characterMovement;
        private readonly ICharacterMovementView _characterMovementView;
        private readonly IUpdateRegister _updateRegister;
        private readonly IInputService _inputService;

        public CharacterMovementPresenter(
            CharacterMovement characterMovement,
            ICharacterMovementView characterMovementView,
            IUpdateRegister updateRegister,
            IInputService inputService,
            IContextState firstState) 
            : base(firstState)
        {
            _characterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            _characterMovementView = characterMovementView ?? throw new ArgumentNullException(nameof(characterMovementView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _inputService = inputService ?? throw new ArgumentNullException(nameof(inputService));
        }

        public void Enable()
        {
            _characterMovement.Direction = Vector3.zero;

            _characterMovement.PropertyChanged += OnPropertyChanged;
            _updateRegister.Register(OnUpdate);
        }

        public void Disable()
        {
            _characterMovement.PropertyChanged += OnPropertyChanged;
            _updateRegister.UnRegister(OnUpdate);
        }

        private void OnUpdate(float deltaTime)
        {
            Apply(_inputService.InputData);
            Update(deltaTime);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnDirectionChanged(sender, e);
        }

        private void OnDirectionChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            if (propertyChangedEventArgs.PropertyName != nameof(CharacterMovement.Direction))
                return;
            
            _characterMovementView.Move(_characterMovement.Direction);
        }
    }
}
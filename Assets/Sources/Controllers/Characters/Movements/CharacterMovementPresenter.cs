using System;
using System.ComponentModel;
using Sources.ControllersInterfaces;
using Sources.Domain.Characters;
using Sources.Infrastructure.StateMachines.ContextStateMachines;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.InfrastructureInterfaces.StateMachines.ContextStateMachines.States;
using Sources.PresentationsInterfaces.Views.Character;
using UnityEngine;

namespace Sources.Controllers.Characters.Movements
{
    public class CharacterMovementPresenter : ContextStateMachine, IPresenter
    {
        private readonly CharacterMovement _characterMovement;
        private readonly ICharacterMovementView _characterMovementView;
        private readonly IUpdateRegister _updateRegister;

        public CharacterMovementPresenter(
            CharacterMovement characterMovement,
            ICharacterMovementView characterMovementView,
            IUpdateRegister updateRegister,
            IContextState firstState) 
            : base(firstState)
        {
            _characterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            _characterMovementView = characterMovementView ?? throw new ArgumentNullException(nameof(characterMovementView));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public void Enable()
        {
            _characterMovement.Direction = Vector3.zero;

            _characterMovement.PropertyChanged += OnPropertyChanged;
        }

        public void Disable()
        {
            _characterMovement.PropertyChanged += OnPropertyChanged;
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
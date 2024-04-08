using Sirenix.OdinInspector;
using Sources.Presentations.Views.Common;
using Sources.Presentations.Views.Players;
using Sources.Presentations.Views.Weapons;
using UnityEngine;

namespace Sources.Presentations.Views.Characters
{
    public class CharacterView : View
    {
        [Required] [SerializeField] private CharacterMovementView _characterMovementView;
        [Required] [SerializeField] private CharacterAnimationView _characterAnimationView;
        [Required] [SerializeField] private MiniGunView _miniGunView;
        [Required] [SerializeField] private CharacterAttackerView _characterAttackerView;
        [Required] [SerializeField] private CharacterHealthView _characterHealthView;
        [Required] [SerializeField] private HealthUi _healthUi;
        [Required] [SerializeField] private CharacterWalletView _characterWalletView;
        [Required] [SerializeField] private PlayerWalletView _playerWalletView;
        
        public CharacterMovementView CharacterMovementView => _characterMovementView;
        public CharacterAnimationView CharacterAnimationView => _characterAnimationView;
        public MiniGunView MiniGunView => _miniGunView;
        public CharacterAttackerView CharacterAttackerView => _characterAttackerView;
        public CharacterHealthView CharacterHealthView => _characterHealthView;
        public HealthUi HealthUi => _healthUi;
        public CharacterWalletView CharacterWalletView => _characterWalletView;
        public PlayerWalletView PlayerWalletView => _playerWalletView;
    }
}
using Sirenix.OdinInspector;
using Sources.Presentations.Views.Abilities;
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
        [Required] [SerializeField] private SawLauncherAbilityView _sawLauncherAbilityView;
        
        public CharacterMovementView CharacterMovementView => _characterMovementView;
        public CharacterAnimationView CharacterAnimationView => _characterAnimationView;
        public MiniGunView MiniGunView => _miniGunView;
        public CharacterAttackerView CharacterAttackerView => _characterAttackerView;
        public SawLauncherAbilityView SawLauncherAbilityView => _sawLauncherAbilityView;
    }
}
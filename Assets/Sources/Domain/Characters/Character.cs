using System;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Abilities;
using Sources.Domain.Characters.Attackers;
using Sources.Domain.Weapons;

namespace Sources.Domain.Characters
{
    public class Character
    {
        public Character(
            CharacterMovement characterMovement,
            CharacterAttacker characterAttacker,
            MiniGun miniGun,
            SawLauncherAbility sawLauncherAbility)
        {
            CharacterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            CharacterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
            MiniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            SawLauncherAbility = sawLauncherAbility ?? throw new ArgumentNullException(nameof(sawLauncherAbility));
        }
        
        public CharacterMovement CharacterMovement { get; }
        public CharacterAttacker CharacterAttacker { get; }
        public MiniGun MiniGun { get; }
        public SawLauncherAbility SawLauncherAbility { get; }
    }
}
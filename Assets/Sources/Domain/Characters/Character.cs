using System;
using Sources.Controllers.Characters.Attackers;
using Sources.Domain.Weapons;

namespace Sources.Domain.Characters
{
    public class Character
    {
        public Character(
            CharacterMovement characterMovement,
            CharacterAttacker characterAttacker,
            MiniGun miniGun)
        {
            CharacterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            CharacterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
            MiniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
        }
        
        public CharacterMovement CharacterMovement { get; }
        public CharacterAttacker CharacterAttacker { get; }
        public MiniGun MiniGun { get; }
    }
}
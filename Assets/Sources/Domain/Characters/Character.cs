using System;

namespace Sources.Domain.Characters
{
    public class Character
    {
        public Character(
            CharacterMovement characterMovement)
        {
            CharacterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
        }
        
        public CharacterMovement CharacterMovement { get; }
    }
}
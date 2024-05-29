using System;

namespace Sources.DomainInterfaces.Models.Characters
{
    public interface ICharacterHealth
    {
        event Action CharacterDie;

        bool IsDied { get; }
    }
}
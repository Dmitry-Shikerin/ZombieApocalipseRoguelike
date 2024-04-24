using System;
using System.Collections.Generic;
using Sources.Domain.Models.Abilities;
using Sources.Domain.Models.Characters.Attackers;
using Sources.Domain.Models.Players;
using Sources.Domain.Models.Weapons;

namespace Sources.Domain.Models.Characters
{
    public class Character
    {
        public Character(
            PlayerWallet playerWallet,
            CharacterHealth characterHealth,
            CharacterMovement characterMovement,
            CharacterAttacker characterAttacker,
            MiniGun miniGun,
            SawLauncherAbility sawLauncherAbility,
            IReadOnlyList<SawLauncher> sawLaunchers)
        {
            PlayerWallet = playerWallet ?? throw new ArgumentNullException(nameof(playerWallet));
            CharacterHealth = characterHealth ?? throw new ArgumentNullException(nameof(characterHealth));
            CharacterMovement = characterMovement ?? throw new ArgumentNullException(nameof(characterMovement));
            CharacterAttacker = characterAttacker ?? throw new ArgumentNullException(nameof(characterAttacker));
            MiniGun = miniGun ?? throw new ArgumentNullException(nameof(miniGun));
            SawLauncherAbility = sawLauncherAbility ?? throw new ArgumentNullException(nameof(sawLauncherAbility));
            SawLaunchers = sawLaunchers ?? throw new ArgumentNullException(nameof(sawLaunchers));
        }

        public PlayerWallet PlayerWallet { get; }
        public CharacterHealth CharacterHealth { get; }
        public CharacterMovement CharacterMovement { get; }
        public CharacterAttacker CharacterAttacker { get; }
        public MiniGun MiniGun { get; }
        public SawLauncherAbility SawLauncherAbility { get; }
        public IReadOnlyList<SawLauncher> SawLaunchers { get; }
    }
}
using System.Collections.Generic;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.NawMeshAgents;

namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyViewBase : INavMeshAgent, ICharacterFollower
    {
        IReadOnlyList<IEnemySkin> Skins { get; }

        ICharacterHealthView CharacterHealthView { get; }

        void SetCharacterHealth(ICharacterHealthView characterHealthView);

        void EnableNavmeshAgent();

        void DisableNavmeshAgent();
    }
}
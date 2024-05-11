using System.Collections.Generic;
using Sources.Presentations.Views.Characters;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IEnemySpawnerView
    {
        IReadOnlyList<IEnemySpawnPoint> SpawnPoints { get; }
        CharacterView CharacterView { get; }
        
        void SetCharacterView(CharacterView characterView);
    }
}
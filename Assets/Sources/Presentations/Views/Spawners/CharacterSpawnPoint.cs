using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class CharacterSpawnPoint : View, ICharacterSpawnPoint
    {
        public Vector3 Position => transform.position;
    }
}
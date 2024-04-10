using Sources.Domain.Spawners.Types;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public interface IItemSpawnPoint
    {
        ItemType ItemType { get; }
        Vector3 Position { get; }
    }
}
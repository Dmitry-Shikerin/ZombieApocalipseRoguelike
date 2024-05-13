using Sources.Domain.Models.Spawners.Types;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Spawners
{
    public interface IItemSpawnPoint
    {
        ItemType ItemType { get; }
        Vector3 Position { get; }
    }
}
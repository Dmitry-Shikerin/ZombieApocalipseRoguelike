using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class BearSpawnPoint : View, IBearSpawnPoint
    {
        public Vector3 Position => transform.position;
    }
}
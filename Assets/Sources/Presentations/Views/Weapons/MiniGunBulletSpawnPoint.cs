using Sources.PresentationsInterfaces.Views.Bullets;
using UnityEngine;

namespace Sources.Presentations.Views.Weapons
{
    public class MiniGunBulletSpawnPoint : View, IBulletSpawnPoint
    {
        public Vector3 Position => transform.position;
        public Transform Transform => transform;
    }
}
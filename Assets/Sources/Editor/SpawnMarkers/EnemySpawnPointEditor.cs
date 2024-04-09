using Sources.Presentations.Views.Spawners;
using UnityEditor;
using UnityEngine;

namespace Sources.Editor.SpawnMarkers
{
    [CustomEditor(typeof(EnemySpawnPoint))]
    public class EnemySpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(EnemySpawnPoint spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}
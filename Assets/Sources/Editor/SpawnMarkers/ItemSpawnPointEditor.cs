using Sources.Presentations.Views.Spawners;
using UnityEditor;
using UnityEngine;

namespace Sources.Editor.SpawnMarkers
{
    [CustomEditor(typeof(ItemSpawnPoint))]
    public class ItemSpawnPointEditor : UnityEditor.Editor
    {
        [DrawGizmo(GizmoType.Active | GizmoType.Pickable | GizmoType.NonSelected)]
        public static void RenderCustomGizmo(ItemSpawnPoint spawner, GizmoType gizmo)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(spawner.transform.position, 0.5f);
        }
    }
}
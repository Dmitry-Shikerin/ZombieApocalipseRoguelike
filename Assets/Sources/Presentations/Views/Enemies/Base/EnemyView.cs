using Sirenix.OdinInspector;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies.Base
{
    public class EnemyView : EnemyViewBase, IEnemyView
    {
        [Required] [SerializeField] private EnemyAnimation _enemyAnimation;

        public EnemyAnimation EnemyAnimation => _enemyAnimation;
    }
}
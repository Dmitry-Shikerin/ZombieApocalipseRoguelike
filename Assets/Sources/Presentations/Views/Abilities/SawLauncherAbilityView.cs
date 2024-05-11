using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Abilities;
using Sources.PresentationsInterfaces.Views.Abilities;
using UnityEngine;

namespace Sources.Presentations.Views.Abilities
{
    public class SawLauncherAbilityView : PresentableView<SawLauncherAbilityPresenter>, 
        ISawLauncherAbilityView
    {
        [SerializeField] private List<SawLauncherView> _sawLauncherViews;
        
        private Transform _targetTransform;

        public IReadOnlyList<SawLauncherView> SawLauncherViews => _sawLauncherViews;

        public void Rotate(Vector3 euler) =>
            transform.Rotate(euler);

        public void Follow() =>
            transform.position = _targetTransform.position;

        public void SetTargetFollow(Transform targetTransform) =>
            _targetTransform = targetTransform;
    }
}
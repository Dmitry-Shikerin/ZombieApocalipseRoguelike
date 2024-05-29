using System.Collections.Generic;
using Sources.Presentations.Views.Abilities;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Abilities
{
    public interface ISawLauncherAbilityView
    {
        IReadOnlyList<SawLauncherView> SawLauncherViews { get; }

        void Rotate(Vector3 euler);

        void Follow();

        void SetTargetFollow(Transform targetTransform);
    }
}
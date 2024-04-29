using System.Collections.Generic;
using Sources.Controllers.Common;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Common;
using UnityEngine;

namespace Sources.Presentations.Views.Common
{
    public class HealthUiText : PresentableView<HealthUiTextPresenter>, IHealthUiText
    {
        [SerializeField] private List<UiText> _damageTexts;

        public IReadOnlyList<IUiText> DamageTexts => _damageTexts;
    }
}
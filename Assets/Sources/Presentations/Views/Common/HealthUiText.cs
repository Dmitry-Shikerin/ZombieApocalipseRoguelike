﻿using System.Collections.Generic;
using Sources.Controllers.Common;
using Sources.Presentations.UI.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Common;
using UnityEngine;

namespace Sources.Presentations.Views.Common
{
    public class HealthUiText : PresentableView<HealthUiTextPresenter>, IHealthUiText
    {
        [SerializeField] private List<TextView> _damageTexts;

        public IReadOnlyList<ITextView> DamageTexts => _damageTexts;
    }
}
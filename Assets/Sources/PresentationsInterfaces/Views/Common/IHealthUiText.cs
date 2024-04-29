﻿using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.PresentationsInterfaces.Views.Common
{
    public interface IHealthUiText
    {
        IReadOnlyList<IUiText> DamageTexts { get; }
    }
}
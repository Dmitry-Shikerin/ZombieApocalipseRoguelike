﻿using System.Collections.Generic;
using Sources.Frameworks.UiFramework.Domain.Commands;
using Sources.Frameworks.UiFramework.Presentation.Buttons.Types;
using Sources.Frameworks.UiFramework.Presentation.Views.Types;
using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.Frameworks.UiFramework.PresentationsInterfaces.Buttons
{
    public interface IUiButton : IButtonView
    {
        float Delay { get; }

        List<ButtonCommandId> OnClickCommandId { get; }

        List<ButtonCommandId> EnableCommandId { get; }

        List<ButtonCommandId> DisableCommandId { get; }

        UseButtonType UseButtonType { get; }

        FormId FormId { get; }
    }
}
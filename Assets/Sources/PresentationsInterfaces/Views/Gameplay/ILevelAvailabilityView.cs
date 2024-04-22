using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Gameplay
{
    public interface ILevelAvailabilityView
    {
        IReadOnlyList<IButtonView> LevelButtons { get; }
    }
}
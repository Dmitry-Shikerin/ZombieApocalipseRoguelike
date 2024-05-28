using System.Collections.Generic;

namespace Sources.PresentationsInterfaces.Views.Gameplay
{
    public interface ILevelAvailabilityView
    {
        IReadOnlyList<ILevelView> Levels { get; }
    }
}
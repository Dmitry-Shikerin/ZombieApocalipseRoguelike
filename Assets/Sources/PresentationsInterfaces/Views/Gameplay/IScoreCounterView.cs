using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Texts;

namespace Sources.PresentationsInterfaces.Views.Gameplay
{
    public interface IScoreCounterView
    {
        IReadOnlyList<IUiText> Texts { get; }
    }
}
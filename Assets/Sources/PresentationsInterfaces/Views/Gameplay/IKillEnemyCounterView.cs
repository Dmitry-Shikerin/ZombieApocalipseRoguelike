using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.UI.Sliders;

namespace Sources.PresentationsInterfaces.Views.Gameplay
{
    public interface IKillEnemyCounterView
    {
        IReadOnlyList<ISliderView> WaveSeparators { get; }

        IImageView KillEnemyBar { get; }
    }
}
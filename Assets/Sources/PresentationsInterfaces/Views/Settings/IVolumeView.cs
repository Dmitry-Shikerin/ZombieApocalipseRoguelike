using System.Collections.Generic;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Images;
using UnityEngine;

namespace Sources.PresentationsInterfaces.Views.Settings
{
    public interface IVolumeView
    {
        Sprite FilledSprite { get; }
        Sprite VoidSprite { get; }
        IReadOnlyList<IImageView> Images { get; }
        IButtonView IncreaseButton { get; }
        IButtonView TurnDownButton { get; }
    }
}
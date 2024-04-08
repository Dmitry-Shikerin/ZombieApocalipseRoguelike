using System.Collections.Generic;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Images;

namespace Sources.PresentationsInterfaces.Views.Upgrades
{
    public interface IUpgradeUi
    {
        IReadOnlyList<IImageView> ImageViews { get; }

        void SetPriceNextUpgrade(string text);
    }
}
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Images;

namespace Sources.PresentationsInterfaces.Views.Gameplay
{
    public interface ILevelView
    {
        IButtonView ButtonView { get; }

        IImageView ImageView { get; }
    }
}
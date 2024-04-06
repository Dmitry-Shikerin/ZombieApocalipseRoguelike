using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.Gameplay
{
    public interface IPauseFormView
    {
        IButtonView HudButtonView { get; }
        IButtonView MainMenuButtonView { get; }
    }
}
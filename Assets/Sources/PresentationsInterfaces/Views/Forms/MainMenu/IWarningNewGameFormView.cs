using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public interface IWarningNewGameFormView
    {
        IButtonView NewGameButtonView { get; }
        IButtonView MainMenuHudButtonView { get; }
    }
}
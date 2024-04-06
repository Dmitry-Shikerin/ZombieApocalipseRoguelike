using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.MainMenu
{
    public interface IMainMenuHudFormView
    {
        IButtonView SettingsButtonView { get; }
        IButtonView AuthorizationButtonView { get; }
        IButtonView LeaderBoardButtonView { get; }
        IButtonView NewGameButtonView { get; }
        IButtonView LoadGameButtonView { get; }
    }
}
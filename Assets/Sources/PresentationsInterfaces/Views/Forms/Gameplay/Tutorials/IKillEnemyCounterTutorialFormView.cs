using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials
{
    public interface IKillEnemyCounterTutorialFormView
    {
        IButtonView HealthBarTutorialButton { get; }
        IButtonView SaveTutorialButton { get; }
        IButtonView MainMenuButton { get; }
    }
}
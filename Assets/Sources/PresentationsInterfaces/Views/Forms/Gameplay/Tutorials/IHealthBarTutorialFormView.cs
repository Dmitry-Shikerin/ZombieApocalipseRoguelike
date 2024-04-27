using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials
{
    public interface IHealthBarTutorialFormView
    {
        IButtonView GreetingTutorialButton { get; }
        IButtonView KillEnemyCounterTutorialButton { get; }
        IButtonView HudFormButton { get; }
    }
}
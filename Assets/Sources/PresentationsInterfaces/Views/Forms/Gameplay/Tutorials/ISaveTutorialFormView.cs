using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials
{
    public interface ISaveTutorialFormView
    {
        IButtonView KillEnemyCounterTutorialButton { get; }
        IButtonView RewardTutorialButton { get; }
        IButtonView HudFormButton { get; }
    }
}
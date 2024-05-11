using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.Gameplay.Tutorials
{
    public interface IGreetingTutorialFormView
    {
        IButtonView GameplayHudButtonView { get; }
        IButtonView HeathBarTutorialButtonView { get; }
    }
}
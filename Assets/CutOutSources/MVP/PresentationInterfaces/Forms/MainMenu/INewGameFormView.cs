using System.Collections.Generic;
using Sources.PresentationsInterfaces.UI.Buttons;

namespace Sources.PresentationsInterfaces.Views.Forms.MainMenu
{
    public interface INewGameFormView
    {
        IButtonView MainMenuButton { get; }
        IButtonView FirstLevelButton { get; }
        IButtonView SecondLevelButton { get; }
        IButtonView ThirdLevelButton { get; }
        IButtonView FourthLevelButton { get; }
    }
}
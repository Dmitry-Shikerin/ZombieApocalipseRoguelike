using Sirenix.OdinInspector;
using Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public class NewGameFormView : FormBase<NewGameFormPresenter>, INewGameFormView
    {
        [Required] [SerializeField] private ButtonView _mainMenuButtonView;
        [Required] [SerializeField] private ButtonView _firstLevelButtonView;
        [Required] [SerializeField] private ButtonView _secondLevelButtonView;
        [Required] [SerializeField] private ButtonView _thirdLevelButtonView;
        [Required] [SerializeField] private ButtonView _fourthLevelButtonView;

        public IButtonView MainMenuButton => _mainMenuButtonView;
        public IButtonView FirstLevelButton => _firstLevelButtonView;
        public IButtonView SecondLevelButton => _secondLevelButtonView;
        public IButtonView ThirdLevelButton => _thirdLevelButtonView;
        public IButtonView FourthLevelButton => _fourthLevelButtonView;
    }
}
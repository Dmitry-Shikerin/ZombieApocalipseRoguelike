using System;
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Forms.MainMenu;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.Views.Forms.Common;
using Sources.PresentationsInterfaces.UI.Buttons;
using UnityEngine;

namespace Sources.Presentations.Views.Forms.MainMenu
{
    public class WarningNewGameFormView : FormBase<WarningNewGameFormPresenter>, IWarningNewGameFormView
    {
        [Required] [SerializeField] private ButtonView _newGameButtonView;
        [Required] [SerializeField] private ButtonView _mainMenuHudButtonView;

        public IButtonView NewGameButtonView => _newGameButtonView;
        public IButtonView MainMenuHudButtonView => _mainMenuHudButtonView;
    }
}
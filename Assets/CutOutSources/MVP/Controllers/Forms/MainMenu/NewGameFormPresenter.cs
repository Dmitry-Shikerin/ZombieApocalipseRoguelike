using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Payloads;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.LoadServices;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.Presentations.Views.Forms.MainMenu;
using Sources.PresentationsInterfaces.Views.Forms.MainMenu;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Forms.MainMenu
{
    public class NewGameFormPresenter : PresenterBase
    {
        private readonly INewGameFormView _view;
        private readonly IMVPFormService _imvpFormService;
        private readonly ILoadService _loadService;
        private readonly ISceneService _sceneService;

        public NewGameFormPresenter(
            INewGameFormView view, 
            IMVPFormService imvpFormService, 
            ILoadService loadService,
            ISceneService sceneService)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _imvpFormService = imvpFormService ?? throw new ArgumentNullException(nameof(imvpFormService));
            _loadService = loadService ?? throw new ArgumentNullException(nameof(loadService));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));
        }

        public override void Enable()
        {
            _view.FirstLevelButton.AddClickListener(LoadFirstLevel);
            _view.SecondLevelButton.AddClickListener(LoadSecondLevel);
            _view.ThirdLevelButton.AddClickListener(LoadThirdLevel);
            _view.FourthLevelButton.AddClickListener(LoadFourthLevel);
            _view.MainMenuButton.AddClickListener(ShowMainMenuForm);
        }

        public override void Disable()
        {
            _view.FirstLevelButton.RemoveClickListener(LoadFirstLevel);
            _view.SecondLevelButton.RemoveClickListener(LoadSecondLevel);
            _view.ThirdLevelButton.RemoveClickListener(LoadThirdLevel);
            _view.FourthLevelButton.RemoveClickListener(LoadFourthLevel);
        }

        private void LoadFirstLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay, new ScenePayload(ModelId.Gameplay, false, false));

        private void LoadSecondLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay2, new ScenePayload(ModelId.Gameplay2, false, false));

        private void LoadThirdLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay3, new ScenePayload(ModelId.Gameplay3, false, false));


        private void LoadFourthLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay4, new ScenePayload(ModelId.Gameplay4, false, false));

        private void ShowMainMenuForm() =>
            _imvpFormService.Show<MainMenuHudFormView>();
    }
}
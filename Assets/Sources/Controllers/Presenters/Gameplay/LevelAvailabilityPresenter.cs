using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Payloads;
using Sources.InfrastructureInterfaces.Services.Forms;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenter : PresenterBase
    {
        private readonly LevelAvailability _levelAvailability;
        private readonly ILevelAvailabilityView _levelAvailabilityView;
        private readonly ISceneService _sceneService;
        private readonly IDomainFormService _domainFormService;

        public LevelAvailabilityPresenter(
            LevelAvailability levelAvailability, 
            ILevelAvailabilityView levelAvailabilityView,
            ISceneService sceneService)
        {
            _levelAvailability = levelAvailability ?? 
                                 throw new ArgumentNullException(nameof(levelAvailability));
            _levelAvailabilityView = levelAvailabilityView ?? 
                                     throw new ArgumentNullException(nameof(levelAvailabilityView));
            _sceneService = sceneService ?? throw new ArgumentNullException(nameof(sceneService));

            if (_levelAvailabilityView.Levels.Count != _levelAvailability.Levels.Count)
                throw new IndexOutOfRangeException(nameof(_levelAvailability.Levels));
        }

        public override void Enable()
        {
            AddButtonListeners();
            HideAvailableLevels();
            ShowAvailableLevels();
        }

        public override void Disable()
        {
            RemoveButtonListeners();
        }

        private void ShowAvailableLevels()
        {
            for (int i = 0; i < _levelAvailability.Levels.Count; i++)
            {
                if (i == 0)
                {
                    _levelAvailabilityView.Levels[i].ImageView.HideImage();
                    _levelAvailabilityView.Levels[i].ButtonView.Enable();
                }
                
                if (_levelAvailability.Levels[i].IsCompleted)
                {
                    _levelAvailabilityView.Levels[i].ImageView.HideImage();
                    _levelAvailabilityView.Levels[i].ButtonView.Enable();
                    
                    if(i == _levelAvailabilityView.Levels.Count - 1)
                        return;
                    
                    _levelAvailabilityView.Levels[i + 1].ImageView.HideImage();
                    _levelAvailabilityView.Levels[i + 1].ButtonView.Enable();
                }
            }
        }

        private void HideAvailableLevels()
        {
            foreach (ILevelView levelView in _levelAvailabilityView.Levels)
            {
                levelView.ImageView.ShowImage();
                levelView.ButtonView.Disable();
            }
        }

        private void AddButtonListeners()
        {
            _levelAvailabilityView.Levels[0].ButtonView.AddClickListener(ShowFirstLevel);
            _levelAvailabilityView.Levels[1].ButtonView.AddClickListener(ShowSecondLevel);
            _levelAvailabilityView.Levels[2].ButtonView.AddClickListener(ShowThirdLevel);
            _levelAvailabilityView.Levels[3].ButtonView.AddClickListener(ShowFourthLevel);
        }

        private void RemoveButtonListeners()
        {
            _levelAvailabilityView.Levels[0].ButtonView.RemoveClickListener(ShowFirstLevel);
            _levelAvailabilityView.Levels[1].ButtonView.RemoveClickListener(ShowSecondLevel);
            _levelAvailabilityView.Levels[2].ButtonView.RemoveClickListener(ShowThirdLevel);
            _levelAvailabilityView.Levels[3].ButtonView.RemoveClickListener(ShowFourthLevel);
        }

        private void ShowFirstLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay, new ScenePayload(ModelId.Gameplay, false, false));

        private void ShowSecondLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay2, new ScenePayload(ModelId.Gameplay2, false, false));
        
        private void ShowThirdLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay3, new ScenePayload(ModelId.Gameplay3, false, false));
        
        private void ShowFourthLevel() =>
            _sceneService.ChangeSceneAsync(
                ModelId.Gameplay4, new ScenePayload(ModelId.Gameplay4, false, false));
    }
}
using System;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Data.Ids;
using Sources.Domain.Models.Gameplay;
using Sources.Domain.Models.Payloads;
using Sources.InfrastructureInterfaces.Services.SceneServices;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine.Events;

namespace Sources.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenter : PresenterBase
    {
        private readonly LevelAvailability _levelAvailability;
        private readonly ILevelAvailabilityView _levelAvailabilityView;
        private readonly ISceneService _sceneService;

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
                    SetAvailableLevel(i);

                if (_levelAvailability.Levels[i].IsCompleted == false)
                    continue;
                
                SetAvailableLevel(i);

                int correctAvailableLevels = _levelAvailabilityView.Levels.Count - 1;
                
                if(i == correctAvailableLevels)
                        return;
                    
                int correctIndex = i + 1;
                SetAvailableLevel(correctIndex);
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

        private void SetAvailableLevel(int index)
        {
            _levelAvailabilityView.Levels[index].ImageView.HideImage();
            _levelAvailabilityView.Levels[index].ButtonView.Enable();
        }

        private void AddButtonListeners()
        {
            for (int i = 0; i < _levelAvailabilityView.Levels.Count; i++)
            {
                UnityAction action = GetShowLevelAction(i);
                _levelAvailabilityView.Levels[i].ButtonView.AddClickListener(action);
            }
        }

        private void RemoveButtonListeners()
        {
            for (int i = 0; i < _levelAvailabilityView.Levels.Count; i++)
            {
                UnityAction action = GetShowLevelAction(i);
                _levelAvailabilityView.Levels[i].ButtonView.RemoveClickListener(action);
            }
        }

        private UnityAction GetShowLevelAction(int index)
        {
            return index switch
            {
                LevelConst.FirstLevel => ShowFirstLevel,
                LevelConst.SecondLevel => ShowSecondLevel,
                LevelConst.ThirdLevel => ShowThirdLevel,
                LevelConst.FourthLevel => ShowFourthLevel,
                _ => throw new ArgumentOutOfRangeException(nameof(index))
            };
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
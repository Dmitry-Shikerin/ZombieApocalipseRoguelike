using System;
using ModestTree;
using Sources.Controllers.Common;
using Sources.Domain.Models.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Controllers.Presenters.Gameplay
{
    public class LevelAvailabilityPresenter : PresenterBase
    {
        private readonly LevelAvailability _levelAvailability;
        private readonly ILevelAvailabilityView _levelAvailabilityView;

        public LevelAvailabilityPresenter(
            LevelAvailability levelAvailability, 
            ILevelAvailabilityView levelAvailabilityView)
        {
            _levelAvailability = levelAvailability ?? 
                                 throw new ArgumentNullException(nameof(levelAvailability));
            _levelAvailabilityView = levelAvailabilityView ?? 
                                     throw new ArgumentNullException(nameof(levelAvailabilityView));

            if (_levelAvailabilityView.Levels.Count != _levelAvailability.Levels.Count)
                throw new IndexOutOfRangeException(nameof(_levelAvailability.Levels));
        }

        public override void Enable()
        {
            HideAvailableLevels();
            ShowAvailableLevels();
        }

        public override void Disable()
        {
            
        }

        //TODO затемнять картинки если они не доступны
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
                    // _levelAvailabilityView.Levels[i].Enable();
                    _levelAvailabilityView.Levels[i].ImageView.HideImage();
                    _levelAvailabilityView.Levels[i].ButtonView.Enable();
                    
                    if(i == _levelAvailabilityView.Levels.Count)
                        return;
                    
                    // _levelAvailabilityView.Levels[i + 1].Enable();
                    _levelAvailabilityView.Levels[i + 1].ImageView.HideImage();
                    _levelAvailabilityView.Levels[i + 1].ButtonView.Enable();

                    Debug.Log("Show nextlevel");
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
    }
}
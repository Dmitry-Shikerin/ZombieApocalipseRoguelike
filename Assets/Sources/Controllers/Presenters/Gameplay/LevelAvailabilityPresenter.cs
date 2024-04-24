using System;
using Sources.Controllers.Common;
using Sources.Domain.Models.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Controllers.Gameplay
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

            if (_levelAvailabilityView.LevelButtons.Count != _levelAvailability.Levels.Count)
                throw new IndexOutOfRangeException(nameof(_levelAvailability.Levels));
        }

        public override void Enable()
        {
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
                if (_levelAvailability.Levels[i].IsCompleted)
                {
                    _levelAvailabilityView.LevelButtons[i].Enable();
                    
                    if(i == _levelAvailabilityView.LevelButtons.Count)
                        return;
                    
                    _levelAvailabilityView.LevelButtons[i + 1].Enable();
                }
            }
        }
    }
}
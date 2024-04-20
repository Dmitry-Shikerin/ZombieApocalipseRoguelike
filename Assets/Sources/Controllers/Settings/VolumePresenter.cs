using System;
using Sources.Controllers.Common;
using Sources.Domain.Setting;
using Sources.PresentationsInterfaces.Views.Forms.Common;
using Sources.PresentationsInterfaces.Views.Settings;
using UnityEngine;

namespace Sources.Controllers.Settings
{
    public class VolumePresenter : PresenterBase
    {
        private readonly Volume _volume;
        private readonly IVolumeView _volumeView;

        public VolumePresenter(Volume volume, IVolumeView volumeView)
        {
            _volume = volume ?? throw new ArgumentNullException(nameof(volume));
            _volumeView = volumeView ?? throw new ArgumentNullException(nameof(volumeView));
        }

        public override void Enable()
        {
            
        }

        public override void Disable()
        {
            
        }
        
        public void IncreaseVolume()
        {
            _volume.Increase();
            ShowSprites(_volume.Step);
        }

        public void TurnDownVolume()
        {
            _volume.TurnDown();
            ShowSprites(_volume.Step);
        }

        private void ShowSprites(int currentStep)
        {
            SetSpriteInRange(0, currentStep, _volumeView.FilledSprite);
            SetSpriteInRange(currentStep, _volumeView.Images.Count, _volumeView.VoidSprite);
        }

        private void SetSpriteInRange(int from, int to, Sprite sprite)
        {
            for (var i = from; i < to; i++)
                _volumeView.Images[i].SetSprite(sprite);
        }
    }
}
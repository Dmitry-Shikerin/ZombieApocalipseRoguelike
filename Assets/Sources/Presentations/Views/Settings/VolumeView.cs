using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Settings;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Settings;
using UnityEngine;

namespace Sources.Presentations.Views.Settings
{
    public class VolumeView : PresentableView<VolumePresenter>, IVolumeView
    {
        [Required] [SerializeField] private ButtonView _increaseButton;
        [Required] [SerializeField] private ButtonView _turnDownButton;
        [Required] [SerializeField] private List<ImageView> _images;
        [Required] [SerializeField] private Sprite _filledSprite;
        [Required] [SerializeField] private Sprite _voidSprite;

        public Sprite FilledSprite => _filledSprite;
        public Sprite VoidSprite => _voidSprite;
        public IReadOnlyList<IImageView> Images => _images;
        public IButtonView IncreaseButton => _increaseButton;
        public IButtonView TurnDownButton => _turnDownButton;
    }
}
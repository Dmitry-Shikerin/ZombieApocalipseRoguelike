using Sirenix.OdinInspector;
using Sources.Presentations.UI.Buttons;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Buttons;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Gameplay
{
    public class LevelView : View, ILevelView
    {
        [Required] [SerializeField] private ButtonView _buttonView;
        [Required] [SerializeField] private ImageView _imageView;

        public IButtonView ButtonView => _buttonView;

        public IImageView ImageView => _imageView;
    }
}
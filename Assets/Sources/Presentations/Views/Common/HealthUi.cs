using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Common;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Common;
using UnityEngine;

namespace Sources.Presentations.Views.Common
{
    public class HealthUi : PresentableView<HealthUiPresenter>, IHealthUi
    {
        [Required] [SerializeField] private ImageView _healthImage;

        public IImageView HealthImage => _healthImage;
    }
}
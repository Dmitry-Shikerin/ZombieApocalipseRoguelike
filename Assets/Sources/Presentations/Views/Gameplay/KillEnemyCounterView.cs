using Sirenix.OdinInspector;
using Sources.Controllers.Gameplay;
using Sources.Presentations.UI.Images;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Gameplay
{
    public class KillEnemyCounterView : PresentableView<KillEnemyCounterPresenter>, IKillEnemyCounterView
    {
        [Required] [SerializeField] private ImageView _killEnemyBarImageView;

        public IImageView KillEnemyBar => _killEnemyBarImageView;
    }
}
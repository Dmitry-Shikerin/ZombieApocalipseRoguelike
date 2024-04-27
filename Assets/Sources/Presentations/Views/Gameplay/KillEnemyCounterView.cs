using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Presentations.UI.Images;
using Sources.Presentations.UI.Sliders;
using Sources.PresentationsInterfaces.UI.Images;
using Sources.PresentationsInterfaces.UI.Sliders;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;

namespace Sources.Presentations.Views.Gameplay
{
    public class KillEnemyCounterView : PresentableView<KillEnemyCounterPresenter>, IKillEnemyCounterView
    {
        [Required] [SerializeField] private ImageView _killEnemyBarImageView;
        //TODO по хорошему инстанциировать
        [SerializeField] private List<SliderView> _waveSeparators;

        public IReadOnlyList<ISliderView> WaveSeparators => _waveSeparators;
        public IImageView KillEnemyBar => _killEnemyBarImageView;
    }
}
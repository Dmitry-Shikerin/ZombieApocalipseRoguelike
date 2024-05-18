using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Gameplay;
using Sources.Frameworks.UiFramework.Presentation.Texts;
using Sources.PresentationsInterfaces.UI.Texts;
using Sources.PresentationsInterfaces.Views.Gameplay;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Presentations.Views.Gameplay
{
    public class ScoreCounterView : PresentableView<ScoreCounterPresenter>, IScoreCounterView
    {
[Required] [SerializeField] private List<UiText> _texts;
        
        public IReadOnlyList<IUiText> Texts => _texts;
    }
}
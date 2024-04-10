using System.Collections.Generic;
using UnityEngine;

namespace Sources.Presentations.Views.YandexSDK
{
    public class LeaderBoardElementViewContainer
    {
        [field: SerializeField] public List<LeaderBoardElementView> LeaderBoardElementViews { get; private set; }
    }
}
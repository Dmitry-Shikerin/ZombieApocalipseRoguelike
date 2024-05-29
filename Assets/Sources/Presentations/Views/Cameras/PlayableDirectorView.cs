using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Playables;

namespace Sources.Presentations.Views.Cameras
{
    public class PlayableDirectorView : View, IPlayableDirectorView
    {
        [Required] [SerializeField] private PlayableDirector _playableDirector;

        public void SetPlayable(PlayableAsset playable)
        {
             _playableDirector.playableAsset = playable;
        }
    }
}
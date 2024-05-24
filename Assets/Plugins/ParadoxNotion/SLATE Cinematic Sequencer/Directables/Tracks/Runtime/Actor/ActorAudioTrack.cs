using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Groups.Runtime;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Tracks.Runtime.Actor
{

    [Attachable(typeof(ActorGroup))]
    public class ActorAudioTrack : AudioTrack
    {

        [UnityEngine.SerializeField]
        protected bool _useAudioSourceOnActor;

        public override bool useAudioSourceOnActor {
            get { return _useAudioSourceOnActor; }
        }
    }
}
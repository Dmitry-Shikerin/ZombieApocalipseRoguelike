using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Groups.Runtime;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Tracks.Runtime.Actor
{

    [Attachable(typeof(ActorGroup))]
    public class ActorPropertiesTrack : PropertiesTrack
    {

        //just add some defaults for convenience
        protected override void OnCreate() {
            base.OnCreate();
            animationData.TryAddParameter(this, typeof(UnityEngine.Transform), "localPosition", null);
            animationData.TryAddParameter(this, typeof(UnityEngine.Transform), "localEulerAngles", null);
        }
    }
}
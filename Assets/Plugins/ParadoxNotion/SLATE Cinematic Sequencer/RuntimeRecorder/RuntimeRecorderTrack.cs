using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Groups.Runtime;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.RuntimeRecorder
{

    [Attachable(typeof(ActorGroup))]
    [Design.Icon(typeof(Animation))]
    [Description("Use the runtime recorder clip to record transform animation (position, rotation, scale) of the actor and its children objects in runtime.\n\nIt is highly recomended to group multiple objects if they are related (like for example a character or chunks of a physics shatter) under an empty root gameobject and use that empty root gameobject as the actor of this group.")]
    public class RuntimeRecorderTrack : CutsceneTrack
    {
        public RuntimeRecorder.Options recorderOptions = RuntimeRecorder.Options.Default();
    }
}
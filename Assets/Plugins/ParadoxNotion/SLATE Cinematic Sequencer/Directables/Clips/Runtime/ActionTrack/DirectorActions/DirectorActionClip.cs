using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Design;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Tracks.Runtime.Director;
using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions
{

    [Attachable(typeof(DirectorActionTrack))]
    abstract public class DirectorActionClip : ActionClip { }
}
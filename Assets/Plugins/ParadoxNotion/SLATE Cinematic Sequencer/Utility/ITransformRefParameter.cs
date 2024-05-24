using Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Utility
{

    public interface ITransformRefParameter
    {
        Transform transform { get; }
        TransformSpace space { get; }
        bool useAnimation { get; }
    }
}
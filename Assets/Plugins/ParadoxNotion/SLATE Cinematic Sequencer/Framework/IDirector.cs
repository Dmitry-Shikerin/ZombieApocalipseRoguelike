using System.Collections.Generic;
using UnityEngine;

namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Framework
{

    ///<summary>Interface for an IDirectable player. e.g. the Cutscene component. This is used for IDirectables to interface with their root.</summary>
    public interface IDirector
    {
        IEnumerable<IDirectable> children { get; }
        GameObject context { get; }
        float length { get; }
        float currentTime { get; set; }
        float previousTime { get; }
        float playbackSpeed { get; set; }
        bool isActive { get; }
        bool isPaused { get; }
        bool isReSampleFrame { get; }
        IEnumerable<GameObject> GetAffectedActors();
        void Play();
        void Pause();
        void Stop();
        void Sample(float time);
        void ReSample();
        void Validate();
        void SendGlobalMessage(string message, object value);
    }
}
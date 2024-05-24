namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime.ActionTrack.DirectorActions.Events
{

    public interface IEvent
    {
        string name { get; }
        void Invoke();
    }
}
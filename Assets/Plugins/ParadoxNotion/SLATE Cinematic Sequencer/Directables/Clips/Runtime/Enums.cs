namespace Plugins.ParadoxNotion.SLATE_Cinematic_Sequencer.Directables.Clips.Runtime
{

    public enum TransformSpace
    {
        CutsceneSpace = 0,
        ActorSpace = 1,
        WorldSpace = 2,
        ParentSpace = 3,
    }

    public enum MiniTransformSpace
    {
        CutsceneSpace = 0,
        WorldSpace = 2,
        ParentSpace = 3,
    }

    public enum ActiveState
    {
        Disable = 0,
        Enable = 1,
        Toggle = 2
    }
}
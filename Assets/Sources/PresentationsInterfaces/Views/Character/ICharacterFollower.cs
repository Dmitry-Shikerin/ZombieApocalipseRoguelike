namespace Sources.PresentationsInterfaces.Views.Character
{
    public interface ICharacterFollower
    {
        ICharacterMovementView CharacterMovementView { get; }

        void SetTargetFollow(ICharacterMovementView target);
    }
}
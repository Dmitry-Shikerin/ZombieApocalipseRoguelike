namespace Sources.PresentationsInterfaces.Views.Enemies
{
    public interface IEnemyAnimation
    {
        void PlayWalk();
        void PlayIdle();
        void PlayDie();
        void PlayAttack();
    }
}
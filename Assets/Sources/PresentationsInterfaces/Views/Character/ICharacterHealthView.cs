namespace Sources.PresentationsInterfaces.Views.Character
{
    public interface ICharacterHealthView
    {
        void TakeDamage(int damage);

        void PlayHealParticle();
    }
}
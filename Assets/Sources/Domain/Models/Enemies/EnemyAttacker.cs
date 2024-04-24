namespace Sources.Domain.Models.Enemies
{
    public class EnemyAttacker
    {
        public EnemyAttacker(int damage)
        {
            Damage = damage;
        }

        public int Damage { get; }
    }
}
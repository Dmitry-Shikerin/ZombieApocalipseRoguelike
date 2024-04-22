namespace Sources.Domain.Enemies
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
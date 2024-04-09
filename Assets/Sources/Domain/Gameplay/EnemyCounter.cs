using System;

namespace Sources.Domain.Gameplay
{
    public class EnemyCounter
    {
        public event Action KillZombiesCountChanged;
        
        public int KillZombies { get; private set; }
        
        public void IncreaseKillCount()
        {
            KillZombies++;
            KillZombiesCountChanged?.Invoke();
        }
    }
}
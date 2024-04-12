using System;
using Sources.DomainInterfaces.FirstActions;

namespace Sources.Domain.Gameplay
{
    public class KillEnemyCounter : IFirstActionModel
    {
        public event Action KillZombiesCountChanged;
        public event Action FirstActionActivate;
        
        public int KillZombies { get; private set; }
        public string Id => nameof(KillEnemyCounter);

        public void IncreaseKillCount()
        {
            if(KillZombies == 0)
                FirstActionActivate?.Invoke();
                
            KillZombies++;
            KillZombiesCountChanged?.Invoke();
        }
    }
}
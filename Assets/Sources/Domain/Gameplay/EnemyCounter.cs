using System;
using Sources.DomainInterfaces.FirstActions;

namespace Sources.Domain.Gameplay
{
    public class EnemyCounter : IFirstActionModel
    {
        public event Action KillZombiesCountChanged;
        
        public int KillZombies { get; private set; }
        
        public void IncreaseKillCount()
        {
            if(KillZombies == 0)
                FirstActionActivate?.Invoke();
                
            KillZombies++;
            KillZombiesCountChanged?.Invoke();
        }

        public event Action FirstActionActivate;
        public string Id => nameof(EnemyCounter);
    }
}
using System;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.FirstActions;

namespace Sources.Domain.Models.Gameplay
{
    public class KillEnemyCounter : IEntity, IFirstActionModel
    {
        public event Action KillZombiesCountChanged;
        public event Action FirstActionActivate;
        
        public int KillZombies { get; private set; }
        public string Id => nameof(KillEnemyCounter);
        public Type Type => GetType();

        public void IncreaseKillCount()
        {
            if(KillZombies == 0)
                FirstActionActivate?.Invoke();
                
            KillZombies++;
            KillZombiesCountChanged?.Invoke();
        }
    }
}
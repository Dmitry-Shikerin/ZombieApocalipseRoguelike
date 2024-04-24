using System;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.FirstActions;

namespace Sources.Domain.Models.Gameplay
{
    public class KillEnemyCounter : IEntity, IFirstActionModel
    {
        public KillEnemyCounter(KillEnemyCounterDto dto)
        {
            Id = dto.Id;
            KillZombies = dto.KillZombies;
        }

        public KillEnemyCounter(
            string id,
            int killZombies)
        {
            Id = id;
            KillZombies = killZombies;
        }

        public event Action KillZombiesCountChanged;
        public event Action FirstActionActivate;

        public int KillZombies { get; private set; }
        public string Id { get; }
        public Type Type => GetType();

        public void IncreaseKillCount()
        {
            if (KillZombies == 0)
                FirstActionActivate?.Invoke();

            KillZombies++;
            KillZombiesCountChanged?.Invoke();
        }
    }
}
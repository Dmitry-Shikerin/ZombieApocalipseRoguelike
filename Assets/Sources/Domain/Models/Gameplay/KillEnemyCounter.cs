using System;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Entities;
using Sources.DomainInterfaces.Models.Gameplay;
using Sources.PresentationsInterfaces.Views.Gameplay;

namespace Sources.Domain.Models.Gameplay
{
    public class KillEnemyCounter : IEntity, IKillEnemyCounter
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

        public int KillZombies { get; private set; }
        public string Id { get; }
        public Type Type => GetType();

        public void IncreaseKillCount()
        {
            KillZombies++;
            KillZombiesCountChanged?.Invoke();
        }
    }
}
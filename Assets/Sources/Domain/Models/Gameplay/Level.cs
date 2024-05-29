using System;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Models.Entities;
using Sources.DomainInterfaces.Models.Gameplay;

namespace Sources.Domain.Models.Gameplay
{
    public class Level : IEntity, ILevel
    {
        public Level(LevelDto levelDto)
        {
            Id = levelDto.Id;
            IsCompleted = levelDto.IsCompleted;
        }

        public Level(
            string id,
            bool isCompleted)
        {
            Id = id;
            IsCompleted = isCompleted;
        }

        public event Action Completed;

        public bool IsCompleted { get; private set; }

        public string Id { get; }

        public Type Type => GetType();

        public void Complete()
        {
            IsCompleted = true;
            Completed?.Invoke();
        }
    }
}
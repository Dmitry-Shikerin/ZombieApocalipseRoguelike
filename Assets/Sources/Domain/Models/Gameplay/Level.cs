using System;
using Sources.Domain.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Models.Gameplay
{
    public class Level : IEntity
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

        //TODO сохранять пройденные уровни
        public bool IsCompleted { get; private set; }
        public string Id { get; }
        public Type Type => GetType();

        public void Complete() =>
            IsCompleted = true;
    }
}
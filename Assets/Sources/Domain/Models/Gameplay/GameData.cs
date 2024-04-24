using System;
using Sources.Domain.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Models.Gameplay
{
    public class GameData : IEntity
    {
        public GameData(GameDataDto gameDataDto)
        {
            Id = gameDataDto.Id;
            IsThereSave = gameDataDto.IsThereSave;
        }
        
        public GameData(string id, bool isThereSave)
        {
            Id = id;
            IsThereSave = isThereSave;
        }

        public string Id { get; }
        public Type Type => GetType();
        public bool IsThereSave { get; private set; }
    }
}
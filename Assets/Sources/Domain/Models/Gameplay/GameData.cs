using System;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Models.Entities;

namespace Sources.Domain.Models.Gameplay
{
    public class GameData : IEntity
    {
        public GameData(GameDataDto gameDataDto)
        {
            Id = gameDataDto.Id;
            WasLaunched = gameDataDto.WasLaunched;
        }
        
        public GameData(string id, bool wasLaunched)
        {
            Id = id;
            WasLaunched = wasLaunched;
        }

        public string Id { get; }
        public Type Type => GetType();
        public bool WasLaunched { get; private set; }
    }
}
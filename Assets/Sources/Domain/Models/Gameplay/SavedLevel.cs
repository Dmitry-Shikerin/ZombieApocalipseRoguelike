using System;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Models.Entities;

namespace Sources.Domain.Models.Gameplay
{
    public class SavedLevel : IEntity
    {
        public SavedLevel(SavedLevelDto savedLevelDto)
        {
            Id = savedLevelDto.Id;
            IsSaved = savedLevelDto.IsSaved;
            SavedLevelId = savedLevelDto.SavedLevelId;
        }
        
        public SavedLevel(
            string id,
            bool isSaved,
            string savedLevelId)
        {
            Id = id;
            IsSaved = isSaved;
            SavedLevelId = savedLevelId;
        }

        public string Id { get; }
        public Type Type => GetType();
        public bool IsSaved { get; set; }
        public string SavedLevelId { get; set; }
    }
}
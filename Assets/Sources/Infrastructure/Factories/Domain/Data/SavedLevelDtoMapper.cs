using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class SavedLevelDtoMapper : ISavedLevelDtoMapper
    {
        public SavedLevelDto MapModelToDto(SavedLevel savedLevel)
        {
            return new SavedLevelDto()
            {
                Id = savedLevel.Id,
                SavedLevelId = savedLevel.SavedLevelId,
                IsSaved = savedLevel.IsSaved,
            };
        }

        public SavedLevel MapDtoToModel(SavedLevelDto savedLevelDto) =>
            new (savedLevelDto);
    }
}
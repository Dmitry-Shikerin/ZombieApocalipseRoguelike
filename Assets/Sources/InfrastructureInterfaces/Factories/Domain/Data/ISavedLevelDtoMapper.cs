using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ISavedLevelDtoMapper
    {
        SavedLevelDto MapModelToDto(SavedLevel savedLevel);

        SavedLevel MapDtoToModel(SavedLevelDto savedLevelDto);
    }
}
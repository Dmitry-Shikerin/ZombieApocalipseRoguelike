using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ILevelDtoMapper
    {
        LevelDto MapModelToDto(Level level);

        Level MapDtoToModel(LevelDto levelDto);
    }
}
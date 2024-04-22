using Sources.Domain.Data;
using Sources.Domain.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface ILevelDtoMapper
    {
        LevelDto MapModelToDto(Level level);
        Level MapDtoToModel(LevelDto levelDto);
    }
}
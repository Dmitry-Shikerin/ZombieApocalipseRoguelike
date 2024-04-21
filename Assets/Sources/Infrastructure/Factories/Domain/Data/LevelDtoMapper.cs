using Sources.Domain.Data;
using Sources.Domain.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class LevelDtoMapper : ILevelDtoMapper
    {
        public LevelDto MapModelToDto(Level level)
        {
            return new LevelDto()
            {
                Id = level.Id,
                IsCompleted = level.IsCompleted
            };
        }

        public Level MapDtoToModel(LevelDto levelDto)
        {
            return new Level(levelDto);
        }
    }
}
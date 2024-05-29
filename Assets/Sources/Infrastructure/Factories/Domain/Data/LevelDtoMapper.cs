using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;
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
                IsCompleted = level.IsCompleted,
            };
        }

        public Level MapDtoToModel(LevelDto levelDto) =>
            new (levelDto);
    }
}
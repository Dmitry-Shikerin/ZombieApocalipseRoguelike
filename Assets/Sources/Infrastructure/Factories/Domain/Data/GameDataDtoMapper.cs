using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class GameDataDtoMapper : IGameDataDtoMapper
    {
        public GameDataDto MapModelToDto(GameData gameData)
        {
            return new GameDataDto()
            {
                Id = gameData.Id,
                WasLaunched = gameData.WasLaunched
            };
        }

        public GameData MapDtoToModel(GameDataDto gameDataDto) =>
            new(gameDataDto);
    }
}
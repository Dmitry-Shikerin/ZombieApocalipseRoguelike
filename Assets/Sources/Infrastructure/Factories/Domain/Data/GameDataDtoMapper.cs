using Sources.Domain.Data;
using Sources.Domain.Gameplay;
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
                IsThereSave = gameData.IsThereSave
            };
        }

        public GameData MapDtoToModel(GameDataDto gameDataDto)
        {
            return new GameData(gameDataDto);
        }
    }
}
using Sources.Domain.Data;
using Sources.Domain.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IGameDataDtoMapper
    {
        GameDataDto MapModelToDto(GameData gameData);
        GameData MapDtoToModel(GameDataDto gameDataDto);
    }
}
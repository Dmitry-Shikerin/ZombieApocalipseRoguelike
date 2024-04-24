using Sources.Domain.Data;
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IGameDataDtoMapper
    {
        GameDataDto MapModelToDto(GameData gameData);
        GameData MapDtoToModel(GameDataDto gameDataDto);
    }
}
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IKillEnemyCounterDtoMapper
    {
        KillEnemyCounterDto MapModelToDto(KillEnemyCounter killEnemyCounter);

        KillEnemyCounter MapDtoToModel(KillEnemyCounterDto killEnemyCounterDto);
    }
}
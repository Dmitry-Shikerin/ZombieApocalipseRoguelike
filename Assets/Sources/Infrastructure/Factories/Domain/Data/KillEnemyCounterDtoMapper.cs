using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class KillEnemyCounterDtoMapper : IKillEnemyCounterDtoMapper
    {
        public KillEnemyCounterDto MapModelToDto(KillEnemyCounter killEnemyCounter)
        {
            return new KillEnemyCounterDto()
            {
                Id = killEnemyCounter.Id,
                KillZombies = killEnemyCounter.KillZombies,
            };
        }

        public KillEnemyCounter MapDtoToModel(KillEnemyCounterDto killEnemyCounterDto) =>
            new(killEnemyCounterDto);
    }
}
using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;

namespace Sources.InfrastructureInterfaces.Factories.Domain.Data
{
    public interface IScoreCounterDtoMapper
    {
        ScoreCounterDto MapModelToDto(ScoreCounter scoreCounter);

        ScoreCounter MapDtoToModel(ScoreCounterDto scoreCount);
    }
}
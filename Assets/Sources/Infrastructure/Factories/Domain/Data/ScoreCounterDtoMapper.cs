using Sources.Domain.Models.Data;
using Sources.Domain.Models.Gameplay;
using Sources.InfrastructureInterfaces.Factories.Domain.Data;

namespace Sources.Infrastructure.Factories.Domain.Data
{
    public class ScoreCounterDtoMapper : IScoreCounterDtoMapper
    {
        public ScoreCounterDto MapModelToDto(ScoreCounter scoreCounter)
        {
            return new ScoreCounterDto()
            {
                TotalScore = scoreCounter.TotalScore,
                Id = scoreCounter.Id,
            };
        }

        public ScoreCounter MapDtoToModel(ScoreCounterDto scoreCount)
        {
            return new ScoreCounter(scoreCount);
        }
    }
}
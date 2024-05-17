using System;
using Sources.Domain.Models.Data;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Models.Gameplay
{
    public class ScoreCounter : IEntity
    {
        public ScoreCounter(ScoreCounterDto dto)
        {
            TotalScore = dto.TotalScore;
            Id = dto.Id;
        }
        
        public ScoreCounter(int totalScore, string id)
        {
            TotalScore = totalScore;
            Id = id;
        }

        public int TotalScore { get; private set; }
        public int CurrentScore { get; private set; }
        public string Id { get; }
        public Type Type => GetType();

        public void SetCurrentScore(int score)
        {
            if(score < 0)
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be positive");
            
            CurrentScore = score;
        }

        public void AddTotalScore()
        {
            if(CurrentScore < 0)
                throw new ArgumentOutOfRangeException(nameof(CurrentScore), "Score must be positive");

            TotalScore += CurrentScore;
        }
    }
}
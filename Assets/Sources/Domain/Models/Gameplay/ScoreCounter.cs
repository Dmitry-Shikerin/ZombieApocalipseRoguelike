using System;
using Sources.DomainInterfaces.Entities;

namespace Sources.Domain.Models.Gameplay
{
    public class ScoreCounter
    {
        public int Score { get; private set; }

        public void SetScore(int score)
        {
            if(score < 0)
                throw new ArgumentOutOfRangeException(nameof(score), "Score must be positive");
            
            Score = score;
        }
    }
}
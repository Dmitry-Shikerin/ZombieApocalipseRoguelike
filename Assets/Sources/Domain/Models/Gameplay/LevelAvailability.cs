using System.Collections.Generic;
using Sources.Domain.Models.Gameplay;

namespace Sources.Domain.Gameplay
{
    public class LevelAvailability
    {
        public LevelAvailability(List<Level> levels)
        {
            Levels = levels;
        }

        public IReadOnlyList<Level> Levels { get; }
    }
}
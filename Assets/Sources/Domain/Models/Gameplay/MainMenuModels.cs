using Sources.Domain.Models.Setting;

namespace Sources.Domain.Models.Gameplay
{
    public class MainMenuModels
    {
        public MainMenuModels(
            Volume volume,
            Level firstLevel,
            Level secondLevel,
            Level thirdLevel,
            Level fourthLevel,
            LevelAvailability levelAvailability,
            GameData gameData,
            SavedLevel savedLevel,
            Tutorial tutorial)
        {
            Volume = volume;
            FirstLevel = firstLevel;
            SecondLevel = secondLevel;
            ThirdLevel = thirdLevel;
            FourthLevel = fourthLevel;
            LevelAvailability = levelAvailability;
            GameData = gameData;
            SavedLevel = savedLevel;
            Tutorial = tutorial;
        }

        public Volume Volume { get; }
        public Level FirstLevel { get; }
        public Level SecondLevel { get; }
        public Level ThirdLevel { get; }
        public Level FourthLevel { get; }
        public LevelAvailability LevelAvailability { get; }
        public GameData GameData { get; }
        public SavedLevel SavedLevel { get; }
        public Tutorial Tutorial { get; }
    }
}
namespace Sources.Domain.Gameplay
{
    public class Level
    {
        //TODO указывать айдишки уровней
        public Level(
            string name,
            bool isCompleted)
        {
            Name = name;
            IsCompleted = isCompleted;
        }

        //TODO сохранять пройденные уровни
        public string Name { get; }
        public bool IsCompleted { get; private set; }

        public void Complete() =>
            IsCompleted = true;
    }
}
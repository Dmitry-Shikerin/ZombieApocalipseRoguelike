namespace Sources.Domain.Models.Setting
{
    public class Settings
    {
        public Settings()
        {
            Volume = new Volume();
            Tutorial = new Tutorial();
        }
        
        public Volume Volume { get; }
        public Tutorial Tutorial { get; }
    }
}
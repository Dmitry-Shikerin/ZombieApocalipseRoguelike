using Sources.Domain.Models.Setting;

namespace Sources.Domain.Setting
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
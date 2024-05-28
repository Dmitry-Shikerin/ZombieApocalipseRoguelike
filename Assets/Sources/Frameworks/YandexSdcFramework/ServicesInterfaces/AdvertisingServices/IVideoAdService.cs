using System;

namespace Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdvertisingServices
{
    public interface IVideoAdService
    {
        bool IsAvailable { get; }
        
        void ShowVideo(Action onCloseCallback);
    }
}
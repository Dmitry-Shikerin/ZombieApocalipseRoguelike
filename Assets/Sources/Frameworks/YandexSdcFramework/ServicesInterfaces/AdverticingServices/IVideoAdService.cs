using System;

namespace Sources.Frameworks.YandexSdcFramework.ServicesInterfaces.AdverticingServices
{
    public interface IVideoAdService
    {
        void ShowVideo(Action onCloseCallback);
    }
}
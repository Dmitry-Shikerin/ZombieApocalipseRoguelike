﻿using Sources.Controllers.Presenters.Settings;
using Sources.Domain.Models.Setting;
using Sources.PresentationsInterfaces.Views.Settings;

namespace Sources.Infrastructure.Factories.Controllers.Presenters.Settings
{
    public class VolumePresenterFactory
    {
        public VolumePresenter Create(Volume volume, IVolumeView volumeView) =>
            new(volume, volumeView);
    }
}
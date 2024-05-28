using System;
using Sources.Controllers.Presenters.Settings;
using Sources.Domain.Models.Setting;
using Sources.Infrastructure.Factories.Controllers.Presenters.Settings;
using Sources.Presentations.Views.Settings;
using Sources.PresentationsInterfaces.Views.Settings;

namespace Sources.Infrastructure.Factories.Views.Settings
{
    public class VolumeViewFactory
    {
        private readonly VolumePresenterFactory _presenterFactory;

        public VolumeViewFactory(VolumePresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? 
                                throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IVolumeView Create(Volume volume, VolumeView volumeView)
        {
            VolumePresenter presenter = _presenterFactory.Create(volume, volumeView);
            
            volumeView.Construct(presenter);
            
            return volumeView;
        }
    }
}
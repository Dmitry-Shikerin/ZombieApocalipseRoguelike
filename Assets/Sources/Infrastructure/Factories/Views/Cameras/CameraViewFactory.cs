using System;
using Sources.Controllers.Presenters.Cameras;
using Sources.Infrastructure.Factories.Controllers.Presenters.Cameras;
using Sources.Presentations.Views.Cameras;
using Sources.PresentationsInterfaces.Views.Cameras;

namespace Sources.Infrastructure.Factories.Views.Cameras
{
    public class CameraViewFactory
    {
        private readonly CameraPresenterFactory _presenterFactory;

        public CameraViewFactory(CameraPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public ICinemachineCameraView Create(CinemachineCameraView cinemachineCameraView)
        {
            CameraPresenter presenter = _presenterFactory.Create(cinemachineCameraView);

            cinemachineCameraView.Construct(presenter);

            return cinemachineCameraView;
        }
    }
}
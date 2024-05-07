using System;
using Sources.Controllers.Bears;
using Sources.Controllers.Presenters.Bears.Movements;
using Sources.Domain.Models.Bears;
using Sources.Infrastructure.Factories.Controllers.Presenters.Bears;
using Sources.Presentations.Views.Bears;
using Sources.PresentationsInterfaces.Views.Bears;

namespace Sources.Infrastructure.Factories.Views.Bears
{
    public class BearViewFactory
    {
        private readonly BearPresenterFactory _bearPresenterFactory;

        public BearViewFactory(BearPresenterFactory bearPresenterFactory)
        {
            _bearPresenterFactory = bearPresenterFactory ?? 
                                    throw new ArgumentNullException(nameof(bearPresenterFactory));
        }

        public IBearView Create(Bear bear, BearView bearView)
        {
            BearPresenter bearPresenter = _bearPresenterFactory.Create(bear, bearView, bearView.BearAnimationView);
            
            bearView.Construct(bearPresenter);
            
            return bearView;
        }
    }
}
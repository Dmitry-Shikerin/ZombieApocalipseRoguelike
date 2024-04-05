using System;
using Sources.Controllers.Bears;
using Sources.Domain.Bears;
using Sources.Infrastructure.Factories.Controllers.Bears;
using Sources.Presentations.Views.Bears;

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
            BearPresenter bearPresenter = _bearPresenterFactory.Create(bear, bearView);
            
            bearView.Construct(bearPresenter);
            
            return bearView;
        }
    }
}
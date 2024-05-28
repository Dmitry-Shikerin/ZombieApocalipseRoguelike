using System;
using Sources.Controllers.Presenters.Bears.Movements;
using Sources.Domain.Models.Bears;
using Sources.Domain.Models.Constants;
using Sources.Infrastructure.Factories.Controllers.Presenters.Bears;
using Sources.Presentations.Views.Bears;
using Sources.Presentations.Views.RootGameObjects;
using Sources.PresentationsInterfaces.Views.Bears;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Sources.Infrastructure.Factories.Views.Bears
{
    public class BearViewFactory
    {
        private readonly RootGameObject _rootGameObject;
        private readonly BearPresenterFactory _bearPresenterFactory;

        public BearViewFactory(
            RootGameObject rootGameObject,
            BearPresenterFactory bearPresenterFactory)
        {
            _rootGameObject = rootGameObject ?? throw new ArgumentNullException(nameof(rootGameObject));
            _bearPresenterFactory = bearPresenterFactory ?? 
                                    throw new ArgumentNullException(nameof(bearPresenterFactory));
        }

        public IBearView Create(Bear bear)
        {
            BearView bearView = Object.Instantiate(
                Resources.Load<BearView>(PrefabPath.Bear), 
                _rootGameObject.BearSpawnPoint.Position, 
                Quaternion.identity);
            
            BearPresenter bearPresenter = _bearPresenterFactory.Create(bear, bearView, bearView.BearAnimationView);
            
            bearView.Construct(bearPresenter);
            
            return bearView;
        }
    }
}
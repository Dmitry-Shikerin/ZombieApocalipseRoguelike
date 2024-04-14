﻿using System;
using Sources.Controllers.Characters;
using Sources.Infrastructure.Factories.Controllers.Characters;
using Sources.Presentations.Views.Characters;
using Sources.Presentations.Views.Characters.EnemyIndicators;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;

namespace Sources.Infrastructure.Factories.Views.Characters
{
    public class EnemyIndicatorViewFactory
    {
        private readonly EnemyIndicatorPresenterFactory _presenterFactory;

        public EnemyIndicatorViewFactory(EnemyIndicatorPresenterFactory presenterFactory)
        {
            _presenterFactory = presenterFactory ?? throw new ArgumentNullException(nameof(presenterFactory));
        }

        public IEnemyIndicatorView Create(EnemyIndicatorView view)
        {
            EnemyIndicatorPresenter presenter = _presenterFactory.Create(view);
            view.Construct(presenter);
            
            return view;
        }
    }
}
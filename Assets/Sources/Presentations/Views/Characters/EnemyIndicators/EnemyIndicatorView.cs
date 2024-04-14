﻿using System;
using System.Collections.Generic;
using Sources.Controllers.Characters;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using UnityEngine;

namespace Sources.Presentations.Views.Characters.EnemyIndicators
{
    public class EnemyIndicatorView : PresentableView<EnemyIndicatorPresenter>, IEnemyIndicatorView
    {
        //TODO по хорошему их нужно инстанциировать
        [SerializeField] private List<EnemyIndicatorArrow> _arrows;

        public Vector3 Position => transform.position;
        public IReadOnlyList<IEnemyIndicatorArrow> Arrows => _arrows;
        
    }
}
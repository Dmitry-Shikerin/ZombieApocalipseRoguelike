using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using Sources.PresentationsInterfaces.Views.Enemies.Base;
using Sources.Utils.CustomCollections;
using UnityEngine;

namespace Sources.Controllers.Presenters.Characters
{
    public class EnemyIndicatorPresenter : PresenterBase
    {
        private readonly IEnemyIndicatorView _enemyIndicatorView;
        private readonly ICustomList<IEnemyView> _enemyCollection;
        private readonly IUpdateRegister _updateRegister;

        public EnemyIndicatorPresenter(
            IEnemyIndicatorView enemyIndicatorView,
            ICustomList<IEnemyView> enemyCollection,
            IUpdateRegister updateRegister)
        {
            _enemyIndicatorView = enemyIndicatorView ??
                                  throw new ArgumentNullException(nameof(enemyIndicatorView));
            _enemyCollection = enemyCollection ??
                                     throw new ArgumentNullException(nameof(enemyCollection));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public override void Enable()
        {
            _enemyCollection.CountChanged += OnEnemyCountChanged;
            _updateRegister.UpdateChanged += OnUpdate;
        }

        public override void Disable()
        {
            _enemyCollection.CountChanged -= OnEnemyCountChanged;
            _updateRegister.UpdateChanged -= OnUpdate;
        }

        private void OnEnemyCountChanged()
        {
            HideViews();
            ShowViews();
        }

        private void OnUpdate(float deltaTime)
        {
            ChangeArrowPositions();
        }

        private void HideViews()
        {
            foreach (IEnemyIndicatorArrow arrow in _enemyIndicatorView.Arrows)
                arrow.Hide();
        }

        private void ShowViews()
        {
            if (_enemyIndicatorView.Arrows.Count < _enemyCollection.Count)
                return; //убрать
            
            //todo вылетает out of range exception
            for (int i = 0; i < _enemyCollection.Count; i++)
                _enemyIndicatorView.Arrows[i].Show();
        }

        private void ChangeArrowPositions()
        {
            if (_enemyIndicatorView.Arrows.Count < _enemyCollection.Count)
                return; //убрать
            
            if (_enemyCollection.Count == 0)
                return;
            
            for (int i = 0; i < _enemyCollection.Count; i++)
            {
                if(_enemyCollection[i] == null)
                    return;
                
                if(_enemyIndicatorView.Arrows[i] == null)
                    return;
                
                Vector3 lookDirection = _enemyCollection[i].Position -
                                        _enemyIndicatorView.Position;
                lookDirection.y = _enemyIndicatorView.Position.y;

                float angle = Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);

                //TODO почему приходится доворачиввать X и почему я  кручу Y а не Z
                // _enemyIndicatorView.Arrows[i].SetAngleEuler(new Vector3(0, angle, 0));
                _enemyIndicatorView.Arrows[i].SetAngleEuler(new Vector3(90, angle, 0));
            }
        }
    }
}
using System;
using Sources.InfrastructureInterfaces.Services.Characters;
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
        private readonly ICustomCollection<IEnemyView> _enemyCollection;
        private readonly IUpdateRegister _updateRegister;
        private readonly IEnemyIndicatorService _enemyIndicatorService;

        public EnemyIndicatorPresenter(
            IEnemyIndicatorView enemyIndicatorView,
            ICustomCollection<IEnemyView> enemyCollection,
            IUpdateRegister updateRegister,
            IEnemyIndicatorService enemyIndicatorService)
        {
            _enemyIndicatorView = enemyIndicatorView ??
                                  throw new ArgumentNullException(nameof(enemyIndicatorView));
            _enemyCollection = enemyCollection ??
                                     throw new ArgumentNullException(nameof(enemyCollection));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
            _enemyIndicatorService = enemyIndicatorService ??
                                     throw new ArgumentNullException(nameof(enemyIndicatorService));
        }

        private bool CanAvailableArrows => _enemyIndicatorView.Arrows.Count > _enemyCollection.Count;

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

        private void OnUpdate(float deltaTime) =>
            ChangeArrowPositions();

        private void HideViews()
        {
            foreach (IEnemyIndicatorArrow arrow in _enemyIndicatorView.Arrows)
                arrow.Hide();
        }

        private void ShowViews()
        {
            if (CanAvailableArrows == false)
                return;

            for (int i = 0; i < _enemyCollection.Count; i++)
                _enemyIndicatorView.Arrows[i].Show();
        }

        private void ChangeArrowPositions()
        {
            if (CanAvailableArrows == false)
                return;

            if (_enemyCollection.Count == 0)
                return;

            for (int i = 0; i < _enemyCollection.Count; i++)
            {
                if (_enemyCollection[i] == null)
                    return;

                if (_enemyIndicatorView.Arrows[i] == null)
                    return;

                float angle = _enemyIndicatorService.GetAngleRotation(
                    _enemyIndicatorView.Position, _enemyCollection[i].Position);
                float correctionXAngle = 90;

                _enemyIndicatorView.Arrows[i].SetAngleEuler(new Vector3(correctionXAngle, angle, 0));
            }
        }
    }
}
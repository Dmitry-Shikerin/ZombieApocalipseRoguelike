﻿using System;
using Sources.Controllers.Common;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.InfrastructureInterfaces.Services.UpdateServices;
using Sources.PresentationsInterfaces.Views.Character.EnemyIndicators;
using UnityEngine;

namespace Sources.Controllers.Characters
{
    public class EnemyIndicatorPresenter : PresenterBase
    {
        private readonly IEnemyIndicatorView _enemyIndicatorView;
        private readonly IEnemyCollectorService _enemyCollectorService;
        private readonly IUpdateRegister _updateRegister;

        public EnemyIndicatorPresenter(
            IEnemyIndicatorView enemyIndicatorView,
            IEnemyCollectorService enemyCollectorService,
            IUpdateRegister updateRegister)
        {
            _enemyIndicatorView = enemyIndicatorView ??
                                  throw new ArgumentNullException(nameof(enemyIndicatorView));
            _enemyCollectorService = enemyCollectorService ?? 
                                     throw new ArgumentNullException(nameof(enemyCollectorService));
            _updateRegister = updateRegister ?? throw new ArgumentNullException(nameof(updateRegister));
        }

        public override void Enable()
        {
            _enemyCollectorService.EnemiesCountChanged += OnEnemyCountChanged;
            _updateRegister.UpdateChanged += OnUpdate;
        }

        public override void Disable()
        {
            _enemyCollectorService.EnemiesCountChanged -= OnEnemyCountChanged;
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
            for (int i = 0; i < _enemyCollectorService.Enemies.Count; i++)
                _enemyIndicatorView.Arrows[i].Show();
        }

        private void ChangeArrowPositions()
        {
            for (int i = 0; i < _enemyCollectorService.Enemies.Count; i++)
            {
                Vector3 lookDirection = _enemyCollectorService.Enemies[i].Position -
                                        _enemyIndicatorView.Position;
                lookDirection.y = _enemyIndicatorView.Position.y;
                
                float angle = Vector3.SignedAngle(Vector3.forward, lookDirection, Vector3.up);
            
                //TODO почему приходится доворачиввать X и почему я  кручу Y а не Z
                _enemyIndicatorView.Arrows[i].SetAngleEuler(new Vector3(90,angle,0));
            }
        }
    }
}
﻿using Sirenix.OdinInspector;
using Sources.Controllers.Presenters.Enemies.Base;
using Sources.Infrastructure.Services.ObjectPools;
using Sources.InfrastructureInterfaces.Services.ObjectPools;
using Sources.Presentations.Views.Common;
using Sources.Presentations.Views.NavMeshAgents;
using Sources.PresentationsInterfaces.Views.Character;
using Sources.PresentationsInterfaces.Views.Enemies;
using UnityEngine;

namespace Sources.Presentations.Views.Enemies
{
    public abstract class EnemyViewBase : NavMeshAgentBase<EnemyPresenter>, IEnemyViewBase
    {
        [Required] [SerializeField] private EnemyHealthView _healthView;
        [Required] [SerializeField] private HealthUi _healthUi;
        [Required] [SerializeField] private HealthUiText _healthUiText;

        private readonly IPoolableObjectDestroyerService _poolableObjectDestroyerService = 
            new PoolableObjectDestroyerService();
        
        public EnemyHealthView EnemyHealthView => _healthView;
        public HealthUi HealthUi => _healthUi;
        public HealthUiText HealthUiText => _healthUiText;
        public ICharacterMovementView CharacterMovementView { get; private set; }
        public ICharacterHealthView CharacterHealthView { get; private set; }

        public override void Destroy()
        {
            _poolableObjectDestroyerService.Destroy(this);
            DestroyPresenter();
        }
        
        public void SetTargetFollow(ICharacterMovementView target) =>
            CharacterMovementView = target;

        public void SetCharacterHealth(ICharacterHealthView characterHealthView) =>
            CharacterHealthView = characterHealthView;

        public void EnableNavmeshAgent() =>
            NavMeshAgent.enabled = true;

        public void DisableNavmeshAgent() =>
            NavMeshAgent.enabled = false;
    }
}
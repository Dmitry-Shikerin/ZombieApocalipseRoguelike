using System;
using System.Collections.Generic;
using System.Linq;
using Sources.Domain.Models.Constants;
using Sources.Domain.Models.Constants.LayerMasks;
using Sources.Infrastructure.Services.Overlaps;
using Sources.Presentations.Views.Characters;
using UnityEngine;

namespace Sources.Infrastructure.Services.Enemies
{
    public class EnemyAttackService : IEnemyAttackService
    {
        private readonly OverlapService _overlapService;

        public EnemyAttackService(OverlapService overlapService)
        {
            _overlapService = overlapService ?? throw new ArgumentNullException(nameof(overlapService));
        }

        public void TryAttack(Vector3 position, int damage)
        {
            IReadOnlyList<CharacterHealthView> characterHealthViews =
                _overlapService.OverlapSphere<CharacterHealthView>(
                    position, 
                    EnemyConst.MassAttackRadius, 
                    Layer.Character, 
                    Layer.Default);

            if (characterHealthViews.Count == 0)
                return;

            characterHealthViews.First().TakeDamage(damage);
        }
    }
}
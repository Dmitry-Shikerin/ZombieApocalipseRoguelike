using System;
using System.Collections.Generic;
using Sources.InfrastructureInterfaces.Services.EnemyCollectors;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.Infrastructure.Services.EnemyCollectors
{
    public class EnemyCollectorService : IEnemyCollectorService
    {
        //TODO очень похоже на модель
        private List<IEnemyView> _enemies = new List<IEnemyView>();
        
        public event Action EnemiesCountChanged; 
        
        public IReadOnlyList<IEnemyView> Enemies => _enemies;

        public void Add(IEnemyView enemyView)
        {
            _enemies.Add(enemyView);
            EnemiesCountChanged?.Invoke();
        }

        public void Remove(IEnemyView enemyView)
        {
            _enemies.Remove(enemyView);
            EnemiesCountChanged?.Invoke();
        }
    }
}
using System;
using System.Collections.Generic;
using Sources.PresentationsInterfaces.Views.Enemies.Base;

namespace Sources.InfrastructureInterfaces.Services.EnemyCollectors
{
    public interface IEnemyCollectorService
    {
        event Action EnemiesCountChanged;
        
        IReadOnlyList<IEnemyView> Enemies { get; }

        void Add(IEnemyView enemyView);
        void Remove(IEnemyView enemyView);
    }
}
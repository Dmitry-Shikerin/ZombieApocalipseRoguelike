using System;
using System.Collections.Generic;
using Sources.DomainInterfaces.Entities;
using UnityEngine;

namespace Sources.Infrastructure.Services.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly Dictionary<string, IEntity> _entities = new Dictionary<string, IEntity>();

        public IReadOnlyDictionary<string, IEntity> Entities => _entities;
        
        public void Add(IEntity entity)
        {
            if (_entities.ContainsKey(entity.Id))
                throw new InvalidOperationException("Entity with this Id already exists");
            
            _entities[entity.Id] = entity;
        }

        public IEntity Get(string id)
        {
            if (_entities.ContainsKey(id) == false)
            {
                Debug.Log(id);
                throw new InvalidOperationException("Entity with this Id does not exist");
            }
            
            return _entities[id];
        }

        public void Release() =>
            _entities.Clear();
    }
}
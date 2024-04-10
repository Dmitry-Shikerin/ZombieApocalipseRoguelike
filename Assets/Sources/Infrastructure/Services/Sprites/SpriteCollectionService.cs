using System;
using System.Collections.Generic;
using Sources.Domain.SpriteCollections;
using Sources.Infrastructure.Services.Icons;
using UnityEngine;

namespace Sources.Infrastructure.Services.Sprites
{
    public class SpriteCollectionService : ISpriteCollectionService
    {
        private readonly Dictionary<string, Sprite> _sprites;
        
        public SpriteCollectionService(SpriteCollection spriteCollection)
        {
            if(spriteCollection == null)
                throw new ArgumentNullException(nameof(spriteCollection));
            
            _sprites = spriteCollection.Sprites ?? throw new NullReferenceException("Sprites is null");
        }

        public Sprite GetIcon(string id)
        {
            if (_sprites.ContainsKey(id) == false)
                throw new NullReferenceException(nameof(id));
            
            return _sprites[id];
        }
    }
}
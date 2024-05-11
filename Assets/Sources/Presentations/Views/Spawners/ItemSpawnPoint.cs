﻿using Sources.Domain.Models.Spawners.Types;
using Sources.PresentationsInterfaces.Views.Spawners;
using UnityEngine;

namespace Sources.Presentations.Views.Spawners
{
    public class ItemSpawnPoint : View, IItemSpawnPoint
    {
        [SerializeField] private ItemType _itemType;
        
        public ItemType ItemType => _itemType;
        public Vector3 Position => transform.position;
    }
}
using System.Collections.Generic;
using Sources.Domain.Dictionaries;
using UnityEngine;

namespace Sources.Domain.SpriteCollections
{
    [CreateAssetMenu(fileName = "SpriteCollection", menuName = "Configs/SpriteCollection", order = 51)]
    public class SpriteCollection : ScriptableObject
    {
        [field: SerializeField] public SpriteSerializedDictionary Sprites { get; private set; }
    }
}
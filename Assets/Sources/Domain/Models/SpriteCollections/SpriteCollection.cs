using Sources.Frameworks.UiFramework.Domain.Dictionaries;
using UnityEngine;

namespace Sources.Domain.Models.SpriteCollections
{
    [CreateAssetMenu(fileName = "SpriteCollection", menuName = "Configs/SpriteCollection", order = 51)]
    public class SpriteCollection : ScriptableObject
    {
        [field: SerializeField] public SpriteSerializedDictionary Sprites { get; private set; }
    }
}
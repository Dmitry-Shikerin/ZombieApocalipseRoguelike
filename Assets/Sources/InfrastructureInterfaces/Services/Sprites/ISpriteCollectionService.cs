using UnityEngine;

namespace Sources.Infrastructure.Services.Icons
{
    public interface ISpriteCollectionService
    {
        Sprite GetIcon(string id);
    }
}
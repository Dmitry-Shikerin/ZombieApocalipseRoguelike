using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Sources.Infrastructure.Services.SceneLoaderServices
{
    public class SceneLoaderService : ISceneLoaderService
    {
        public async UniTask LoadSceneAsync(string sceneName) =>
            await SceneManager.LoadSceneAsync(sceneName);
    }
}
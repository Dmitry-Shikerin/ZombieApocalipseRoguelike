using Cysharp.Threading.Tasks;

namespace Sources.Infrastructure.Services.SceneLoaderServices
{
    public interface ISceneLoaderService
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}
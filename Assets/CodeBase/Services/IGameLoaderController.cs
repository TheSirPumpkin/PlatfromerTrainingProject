using Infrastructure.DAL;

namespace Services
{
    public interface IGameLoaderController : IService
    {
        void LoadLevelByPath(string path);
        LevelsData GetLoadedLevel();
    }
}
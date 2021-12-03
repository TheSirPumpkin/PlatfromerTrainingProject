using Infrastructure.DAL;

namespace Services
{
    public interface IGameLoaderController : IService
    {
        void LoadLevelByData(LevelsData level/*string path*/);
        LevelsData GetLoadedLevel();
    }
}
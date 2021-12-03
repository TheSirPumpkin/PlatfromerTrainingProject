using Services;
using Infrastructure.DAL;
using UnityEngine;

namespace Infrastructure.BLL
{
    public class GameLoaderController : IGameLoaderController
    {
        private LevelsData currentLoadedLevel;
        public void LoadLevelByData(LevelsData level)
        {
            currentLoadedLevel = level;//Resources.Load<LevelsData>(path);
            Application.LoadLevel(currentLoadedLevel.LevelToLoad);
        }
        public LevelsData GetLoadedLevel()
        {
            return currentLoadedLevel;
        }
    }
}
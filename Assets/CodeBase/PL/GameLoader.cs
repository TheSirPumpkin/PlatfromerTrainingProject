using Services;
using Infrastructure.BLL;
using UnityEngine;

namespace Infrastructure.PL
{
    public class GameLoader : MonoBehaviour
    {
        public static GameLoader Instance;
        public ScriptableObjectsContainer scriptableObjectsContainerPrefab;
        private Bootsrapper bootsrapper;
        private IGameLoaderController gameLoaderController;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;

                Instantiate(scriptableObjectsContainerPrefab, transform);

                bootsrapper = new Bootsrapper(AllServices.Container);

                DontDestroyOnLoad(this);

                CheckInitialLevel();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private static void CheckInitialLevel()
        {
            if (Application.loadedLevel != 0)
            {
                AllServices.Container.Single<IGameLoaderController>().LoadLevelByData(ScriptableObjectsContainer.Instance.MainMenuLevelData);
            }
        }
    }
}

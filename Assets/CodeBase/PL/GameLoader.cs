using Services;
using Infrastructure.BLL;
using UnityEngine;

namespace Infrastructure.PL
{
    public class GameLoader : MonoBehaviour
    {
        public IGameLoaderController GameLoaderController;

        private Bootsrapper bootsrapper;

        private void Awake()
        {
            bootsrapper = new Bootsrapper(AllServices.Container);

            DontDestroyOnLoad(this);
        }
    }
}

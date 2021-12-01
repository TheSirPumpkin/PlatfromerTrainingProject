using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hud.BLL
{
    public class GameStopScreen : IGameStopScreen
    {
        private GameObject endGameScreen;
        private IGameLoaderController gameLoaderController;

        public GameStopScreen(IGameLoaderController gameLoaderController)
        {
            this.gameLoaderController = gameLoaderController;
        }

        public void InitEndGameScreen(GameObject endGamePanel)
        {
            endGameScreen = endGamePanel;
        }
        public void CallEndGameScreen()
        {
            endGameScreen.SetActive(true);
        }
        public void Logout()
        {
            PlayerPrefs.SetString("Account", "");
            gameLoaderController.LoadLevelByPath(PathConstants.MainMenuLEvelPath);
        }

        public void Pause()
        {
            throw new System.NotImplementedException();
        }

        public void Restart()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        public void Unpause()
        {
            throw new System.NotImplementedException();
        }

        public void DisableEndGameScreen()
        {
            endGameScreen.SetActive(false);
        }
    }
}

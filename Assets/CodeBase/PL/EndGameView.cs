using Hud.BLL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hud.PL
{
    public class EndGameView : MonoBehaviour
    {
        public GameObject EndGamePanel;

        private GameStopScreen gameStopScreen;
        private void Start()
        {
            gameStopScreen = AllServices.Container.Single<IGameStopScreen>() as GameStopScreen;
            gameStopScreen.InitEndGameScreen(EndGamePanel);
        }
        public void Restart()
        {
            AllServices.Container.Single<IPlayerHealth>().Ressurect();
            AllServices.Container.Single<IGameStopScreen>().Restart();
        }

        public void Logout()
        {
            AllServices.Container.Single<IGameStopScreen>().Logout();
        }
    }
}

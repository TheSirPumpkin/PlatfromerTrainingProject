namespace Services
{
    public interface IGameStopScreen : IService
    {
        void Logout();
        void Pause();
        void Unpause();
        void Restart();
        void CallEndGameScreen();
        void DisableEndGameScreen();
    }
}
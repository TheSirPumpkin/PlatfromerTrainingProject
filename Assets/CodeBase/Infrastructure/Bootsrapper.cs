using Enemy.BLL;
using Hud.BLL;
using Infrastructure.BLL;
using Player.BLL;
using Services;

namespace Infrastructure
{
    public class Bootsrapper
    {
        private readonly AllServices Container;

        public Bootsrapper(AllServices container)
        {
            Container = container;

            RegisterServices();
        }
        private void RegisterServices()
        {

            Container.RegisterSingle<IGameLoaderController>(new GameLoaderController());
            Container.RegisterSingle<IPlayerAttack>(new AttackDetection());
            Container.RegisterSingle<ICameraMovement>(new CameraFollowController());
            Container.RegisterSingle<IEnemySkeletonAttack>(new EnemySkeletonAttackController());
            Container.RegisterSingle<IGameStopScreen>(new GameStopScreen(Container.Single<IGameLoaderController>()));
            Container.RegisterSingle<IPlayerHealth>(new PlayerHealthController(Container.Single<IGameStopScreen>()));
            Container.RegisterSingle<IHealthHud>(new HealthbarController(Container.Single<IPlayerHealth>()));
            Container.RegisterSingle<ILevelCreator>(new LevelCreatorController());
        }
    }
}

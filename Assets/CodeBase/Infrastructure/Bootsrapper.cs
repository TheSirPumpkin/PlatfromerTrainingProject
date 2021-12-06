using Enemy.BLL;
using Hud.BLL;
using Infrastructure.BLL;
using Player.BLL;
using Player.Inventroy.BLL;
using Services;
using UnityEngine;

namespace Infrastructure
{
    public class Bootsrapper
    {
        private readonly AllServices container;

        public Bootsrapper(AllServices container)
        {
            this.container = container;

            RegisterServices();
        }
        private void RegisterServices()
        {
            container.RegisterSingle<IGameLoaderController>(new GameLoaderController());
            container.RegisterSingle<IPlayerAttack>(new AttackDetection());
            container.RegisterSingle<ICameraMovement>(new CameraFollowController());
            container.RegisterSingle<IEnemySkeletonAttack>(new EnemySkeletonAttackController());
            container.RegisterSingle<IGameStopScreen>(new GameStopScreen(container.Single<IGameLoaderController>()));
            container.RegisterSingle<IPlayerInventory>(new PlayerInventoryController());
            container.RegisterSingle<IPlayerHealth>(new PlayerHealthController(container.Single<IGameStopScreen>(), container.Single<IPlayerInventory>()));
            container.RegisterSingle<IHealthHud>(new HealthbarController(container.Single<IPlayerHealth>()));
            container.RegisterSingle<ILevelCreator>(new LevelCreatorController());

#if UNITY_EDITOR || UNITY_STANDALONE || UNITY_WEBGL
            container.RegisterSingle<IPlayeController>(new PlayerControllerStandalone(container.Single<IPlayerHealth>()));
#endif

            container.RegisterSingle<IInventoryItem>(new InventoryItemController(container.Single<IPlayerInventory>()));
            container.RegisterSingle<IInventoryScreen>(new InventoryScreenController(container.Single<IPlayerInventory>(),
                container.Single<IPlayerHealth>()));

        }
    }
}

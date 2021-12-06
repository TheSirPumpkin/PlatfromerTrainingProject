using Services;
using UnityEngine;

namespace Player.PL
{
    public class PlayerHealthView : MonoBehaviour
    {
        public Animator PlayerAnimator;
        public AudioSource AudioSource;
        private IPlayerHealth playerHealthController;
        private IHealthHud healthHud;
        private IInventoryScreen inventoryScreen;

        private void Start()
        {
            playerHealthController = AllServices.Container.Single<IPlayerHealth>();
            healthHud = AllServices.Container.Single<IHealthHud>();
            inventoryScreen= AllServices.Container.Single<IInventoryScreen>();

            playerHealthController.InitPlayerHealthControllerFromView(PlayerAnimator, healthHud, inventoryScreen);
        }
        public void TakeDamage(int damage)
        {
            playerHealthController.TakeDamage(damage, AudioSource);
        }
    }
}
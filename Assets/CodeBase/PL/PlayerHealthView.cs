using Player.BLL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PL
{
    public class PlayerHealthView : MonoBehaviour
    {
        public Animator PlayerAnimator;
        public AudioSource AudioSource;
        private IPlayerHealth playerHealthController;
        private IHealthHud healthHud;
        private void Start()
        {
            playerHealthController = AllServices.Container.Single<IPlayerHealth>();
            healthHud = AllServices.Container.Single<IHealthHud>();
            playerHealthController.InitPlayerHealthController(PlayerAnimator);
        }
        public void TakeDamage(int damage)
        {
            playerHealthController.TakeDamage(damage, AudioSource);
            healthHud.SetHealth();
        }
    }
}
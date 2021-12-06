using Player.Inventroy.DAL;
using UnityEngine;

namespace Services
{
    public interface IPlayerHealth : IService
    {
        bool Dead { get; set; }
        void TakeDamage(int damage, AudioSource audio);
        void RestoreHealth(int amount, ItemObject item);
        void Die();
        int GetInitialHealth();
        int GetCurrentHealth();
        void Ressurect();
        void InitPlayerHealthControllerFromView(Animator playerAnimator, IHealthHud healthHud, IInventoryScreen inventoryScreen);


    }
}

using UnityEngine;

namespace Services
{
    public interface IPlayerHealth : IService
    {
        bool Dead { get; set; }
        void TakeDamage(int damage, AudioSource audio);
        void Die();
        int GetInitialHealth();
        int GetCurrentHealth();
        void Ressurect();
        void InitPlayerHealthController(Animator playerAnimator);


    }
}

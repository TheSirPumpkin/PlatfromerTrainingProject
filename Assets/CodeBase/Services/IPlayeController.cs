
using UnityEngine;

namespace Services
{
    public interface IPlayeController : IService
    {
        void Move();
        void Attack();
        void ResetAttack();
        void InitFromView(Transform player, Animator animator, Rigidbody2D rBody);
    }
}

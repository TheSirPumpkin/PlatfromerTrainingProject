
using UnityEngine;

namespace Services
{
    public interface IPlayeController : IService
    {
        float PlayerSpeed { get; }
        string LightAttackInput { get; }
        string HeavyAttackInput { get; }
        string MoveAxis { get; }
        string JumpButton { get; }
        string InventoryButton { get; }
        void Move();
        void Attack();
        void ResetAttack();
        void InitFromView(Transform player, Animator animator, Rigidbody2D rBody);
    }
}

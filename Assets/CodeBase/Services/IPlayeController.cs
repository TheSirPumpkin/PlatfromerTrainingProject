
namespace Services
{
    public interface IPlayeController : IService
    {
        void Move();
        void Attack();
        void ResetAttack();
    }
}

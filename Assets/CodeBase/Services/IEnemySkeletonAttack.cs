namespace Services
{
    public interface IEnemySkeletonAttack : IService
    {
        void DealDamage(Player.PL.PlayerHealthView player);
    }
}

namespace Services
{
    public interface IPlayerAttack : IService
    {
        void InflictDamage(IEnemy enemy);
    }
}

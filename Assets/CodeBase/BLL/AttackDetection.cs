using Player.DAL;
using Services;
using UnityEngine;

namespace Player.BLL
{
    public class AttackDetection : IPlayerAttack
    {
        private AttackDetectionData attackData;

        private float damage;

        public AttackDetection()
        {
            attackData = ScriptableObjectsContainer.Instance.PlayerAttackStatsData;//Resources.Load<AttackDetectionData>(PathConstants.PlayerAttackStatsPath);

            damage = attackData.Damage;
        }
        public void InflictDamage(IEnemy enemy)
        {
            enemy.TakeDamage(damage);
        }
    }
}

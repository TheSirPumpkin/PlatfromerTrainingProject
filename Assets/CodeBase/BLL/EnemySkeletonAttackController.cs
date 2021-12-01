using Enemy.DAL;
using Player.PL;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy.BLL
{
    public class EnemySkeletonAttackController : IEnemySkeletonAttack
    {
        private EnemyAttackData enemyAttackData;
        private int damage;
        public EnemySkeletonAttackController()
        {
            enemyAttackData = Resources.Load<EnemyAttackData>(PathConstants.EnemyAttackDataPath);
            damage = enemyAttackData.SkeletonDamage;
        }

        public void DealDamage(PlayerHealthView player)
        {
            player.TakeDamage(damage);
        }
    }
}

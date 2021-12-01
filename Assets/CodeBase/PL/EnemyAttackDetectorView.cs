using Player.PL;
using Services;
using UnityEngine;

namespace Enemy.PL
{
    public class EnemyAttackDetectorView : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.localPosition = Vector2.zero;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            PlayerHealthView player = collision.GetComponent<PlayerHealthView>();

            if (player != null)
            {
                AllServices.Container.Single<IEnemySkeletonAttack>().DealDamage(player);
            }
        }
    }
}
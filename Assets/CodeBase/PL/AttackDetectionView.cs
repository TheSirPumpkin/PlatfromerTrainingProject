using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player.PL
{
    public class AttackDetectionView : MonoBehaviour
    {
        private void OnEnable()
        {
            transform.localPosition = Vector2.zero;
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
                IEnemy enemy = collision.gameObject.GetComponent<MonoBehaviour>() as IEnemy;

                if (enemy != null)
                {
                    AllServices.Container.Single<IPlayerAttack>().InflictDamage(enemy);
                }
           
        }
    }
}